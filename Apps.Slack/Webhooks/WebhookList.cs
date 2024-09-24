using Apps.Slack.Webhooks.Handlers;
using Apps.Slack.Webhooks.Output;
using Apps.Slack.Webhooks.Payload;
using Blackbird.Applications.Sdk.Common.Webhooks;
using System.Net;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Blackbird.Applications.Sdk.Common.Invocation;
using Apps.Slack.Actions;
using Apps.Slack.Models.Responses.Message;
using Apps.Slack.Api;
using RestSharp;
using Apps.Slack.Invocables;
using Apps.Slack.Models.Requests.Channel;
using Apps.Slack.Extensions;
using Apps.Slack.Models.Requests.Thread;
using Apps.Slack.Models.Requests.Message;
using System.Threading;

namespace Apps.Slack.Webhooks;

[WebhookList]
public class WebhookList : SlackInvocable
{
    private MessageActions MessageActions { get; set; }

    public WebhookList(InvocationContext invocationContext) : base(invocationContext)
    {
        MessageActions = new MessageActions(invocationContext, null);
    }

    private async Task<FileMessageDto?> GetMessage(string channel, string timestamp)
    {
        var endpoint =
            $"/conversations.replies?channel={channel}&ts={timestamp}&limit=1&inclusive=true";
        var request = new SlackRequest(endpoint, Method.Get, Creds);

        var response = await Client.ExecuteWithErrorHandling<GetMessageDto>(request);

        return response.Messages.Where(x => x.Ts == timestamp).FirstOrDefault();
    }

    [Webhook("On app mentioned", typeof(AppMentionedHandler),
        Description = "Triggered when the app is mentioned (@Blackbird)")]
    public async Task<WebhookResponse<GetMessageResponse>> AppMentioned(WebhookRequest webhookRequest,
        [WebhookParameter] ChannelRequest input, [WebhookParameter] ThreadRequest thread)
    {
        var payload = JsonConvert.DeserializeObject<BasePayload<AppMentionedEvent>>(webhookRequest.Body.ToString());

        if (payload == null)
            throw new Exception("No serializable payload was found in incoming request.");

        var channelId = input.ChannelId ?? input.ManualChannelId;
        if (channelId != null && payload.Event.Channel != channelId)
            return new WebhookResponse<GetMessageResponse>
            {
                HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
                ReceivedWebhookRequestType = WebhookRequestType.Preflight
            };

        var messageWithoutMentionedUser = Regex.Replace(payload.Event.Text, "<@.+> ", "");

        var completeMessage = await GetMessage(payload.Event.Channel, payload.Event.Ts);
        completeMessage.Text = messageWithoutMentionedUser;

        if (thread.ThreadTimestamp != null && thread.ThreadTimestamp != completeMessage?.Thread_ts)
            return new WebhookResponse<GetMessageResponse>
            {
                HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
                ReceivedWebhookRequestType = WebhookRequestType.Preflight
            };

        return new WebhookResponse<GetMessageResponse>
        {
            HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
            Result = new GetMessageResponse
            {
                MessageText = completeMessage.Text,
                ChannelId = payload.Event.Channel,
                Timestamp = completeMessage.Ts,
                ThreadTimestamp = completeMessage.Thread_ts,
                User = completeMessage.User,
                HasAttachments = completeMessage.Files != null && completeMessage.Files.Any(),
            },
            ReceivedWebhookRequestType = WebhookRequestType.Default,
        };
    }

    [Webhook("On message", typeof(ChannelMessageHandler), Description = "Triggered whenever any new message is posted")]
    public async Task<WebhookResponse<GetMessageResponse>> ChannelMessage(WebhookRequest webhookRequest,
        [WebhookParameter] OnMessageWebhookParameter input, [WebhookParameter] ChannelRequest channel, [WebhookParameter] ThreadRequest thread)
    {
        var payload =
            JsonConvert.DeserializeObject<BasePayload<ChannelFileMessageEvent>>(webhookRequest.Body.ToString());

        if (payload == null)
            throw new Exception("No serializable payload was found in incoming request.");

        var channelId = channel.ChannelId ?? channel.ManualChannelId;
        if (channelId != null && payload.Event.Channel != channelId)
            return new WebhookResponse<GetMessageResponse>
            {
                HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
                ReceivedWebhookRequestType = WebhookRequestType.Preflight
            };

        var completeMessage = await GetMessage(payload.Event.Channel, payload.Event.Ts);

        var isReply = completeMessage.Thread_ts != null;

        if (input.ReplyHandling == "no_replies" && isReply)
            return new WebhookResponse<GetMessageResponse>()
            {
                HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
                ReceivedWebhookRequestType = WebhookRequestType.Preflight
            };

        if (input.ReplyHandling == "only_replies" && !isReply)
            return new WebhookResponse<GetMessageResponse>()
            {
                HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
                ReceivedWebhookRequestType = WebhookRequestType.Preflight
            };

        var hasFiles = completeMessage?.Files != null && completeMessage.Files.Any();

        if (input.TriggerOnlyOnFiles is true && !hasFiles)
            return new WebhookResponse<GetMessageResponse>()
            {
                HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
                ReceivedWebhookRequestType = WebhookRequestType.Preflight
            };

        if (thread.ThreadTimestamp != null && thread.ThreadTimestamp != completeMessage?.Thread_ts)
            return new WebhookResponse<GetMessageResponse>
            {
                HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
                ReceivedWebhookRequestType = WebhookRequestType.Preflight
            };

        return new WebhookResponse<GetMessageResponse>
        {
            HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
            Result = new GetMessageResponse
            {
                MessageText = completeMessage.Text,
                ChannelId = payload.Event.Channel,
                Timestamp = completeMessage.Ts,
                ThreadTimestamp = completeMessage.Thread_ts,
                User = completeMessage.User,
                HasAttachments = hasFiles,
            },
            ReceivedWebhookRequestType = WebhookRequestType.Default,
        };
    }

    [Webhook("On member joined channel", typeof(MemberJoinedChannelHandler),
        Description = "Triggered when a member joins a channel")]
    public Task<WebhookResponse<MemberJoinedEvent>> MemberJoinedChannel(WebhookRequest webhookRequest)
    {
        var payload = JsonConvert.DeserializeObject<BasePayload<MemberJoinedEvent>>(webhookRequest.Body.ToString());

        if (payload == null)
            throw new Exception("No serializable payload was found in incoming request.");

        return Task.FromResult(new WebhookResponse<MemberJoinedEvent>
        {
            HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
            Result = payload.Event,
        });
    }

    [Webhook("On reaction added", typeof(MessageReactionHandler),
        Description = "Triggered whenever someone reacts to a message with an emoji")]
    public async Task<WebhookResponse<ChannelMessageWithReaction>> MessageReaction(WebhookRequest webhookRequest,
        [WebhookParameter] ChannelRequest input, [WebhookParameter] OptionalEmojiInput emoji, [WebhookParameter] MessageRequest message)
    {
        var payload = JsonConvert.DeserializeObject<BasePayload<MessageReactionEvent>>(webhookRequest.Body.ToString());

        if (payload == null)
            throw new Exception("No serializable payload was found in incoming request.");

        var channelId = input.ChannelId ?? input.ManualChannelId;
        if (channelId != null && payload.Event.Item.Channel != channelId)
            return new WebhookResponse<ChannelMessageWithReaction>
            {
                HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
                ReceivedWebhookRequestType = WebhookRequestType.Preflight
            };

        if (emoji.Reaction != null && payload.Event.Reaction != emoji.Reaction)
            return new WebhookResponse<ChannelMessageWithReaction>
            {
                HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
                ReceivedWebhookRequestType = WebhookRequestType.Preflight
            };

        if (message.MessageTimestamp != null && message.MessageTimestamp != payload.Event.Item.Ts)
            return new WebhookResponse<ChannelMessageWithReaction>
            {
                HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
                ReceivedWebhookRequestType = WebhookRequestType.Preflight
            };

        var completeMessage = await GetMessage(payload.Event.Item.Channel, payload.Event.Item.Ts);
        return new WebhookResponse<ChannelMessageWithReaction>
        {
            HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
            Result = new ChannelMessageWithReaction
            {
                MessageText = completeMessage.Text,
                ChannelId = payload.Event.Item.Channel,
                Timestamp = completeMessage.Ts,
                ThreadTimestamp = completeMessage.Thread_ts,
                User = completeMessage.User,
                HasAttachments = completeMessage.Files != null && completeMessage.Files.Any(),
                Reaction = payload.Event.Reaction,
                EventTimestamp = payload.Event.EventTs.ToDateTime()
            },
            ReceivedWebhookRequestType = WebhookRequestType.Default,
        };
    }

    // Todo: For some reason this doesn't trigger

    //[Webhook("On reaction removed", typeof(ReactionRemovedHandler), Description = "Triggered whenever someone removed a reaction from a message")]
    //public async Task<WebhookResponse<ChannelMessageWithReaction>> MessageReactionRemoved(WebhookRequest webhookRequest, [WebhookParameter] ChannelInputParameter input, [WebhookParameter] OptionalEmojiInput emoji)
    //{
    //    var payload = JsonConvert.DeserializeObject<BasePayload<MessageReactionEvent>>(webhookRequest.Body.ToString());

    //    if (payload == null)
    //        throw new Exception("No serializable payload was found in incoming request.");

    //    if (input.ChannelId != null && payload.Event.Item.Channel != input.ChannelId)
    //        return new WebhookResponse<ChannelMessageWithReaction> { HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK), ReceivedWebhookRequestType = WebhookRequestType.Preflight };

    //    if (emoji.Reaction != null && payload.Event.Reaction != emoji.Reaction)
    //        return new WebhookResponse<ChannelMessageWithReaction> { HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK), ReceivedWebhookRequestType = WebhookRequestType.Preflight };

    //    var completeMessage = await MessageActions.GetMessageFiles(new Models.Requests.Message.GetMessageParameters { ChannelId = payload.Event.Item.Channel, Timestamp = payload.Event.Item.Ts });

    //    return new WebhookResponse<ChannelMessageWithReaction>
    //    {
    //        HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
    //        Result = new ChannelMessageWithReaction
    //        {
    //            ChannelId = completeMessage.ChannelId,
    //            Timestamp = completeMessage.Timestamp,
    //            User = completeMessage.User,
    //            MessageText = completeMessage.MessageText,
    //            FilesUrls = completeMessage.FilesUrls,
    //            Reaction = payload.Event.Reaction,
    //        },
    //        ReceivedWebhookRequestType = WebhookRequestType.Default,
    //    };
    //}
}