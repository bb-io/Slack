using Apps.Slack.Webhooks.Handlers;
using Apps.Slack.Webhooks.Output;
using Apps.Slack.Webhooks.Payload;
using Blackbird.Applications.Sdk.Common.Webhooks;
using System.Net;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Blackbird.Applications.Sdk.Common.Invocation;
using Apps.Slack.Models.Responses.Message;
using Apps.Slack.Api;
using RestSharp;
using Apps.Slack.Invocables;
using Apps.Slack.Models.Requests.Channel;
using Apps.Slack.Extensions;
using Apps.Slack.Models.Requests.Thread;
using Apps.Slack.Models.Requests.Message;
using Blackbird.Applications.Sdk.Common.Files;
using Blackbird.Applications.SDK.Extensions.FileManagement.Interfaces;
using Apps.Slack.Actions;
using Apps.Slack.Models.Responses.File;

namespace Apps.Slack.Webhooks;

[WebhookList]
public class WebhookList : SlackInvocable
{
    private readonly IFileManagementClient _fileManagementClient;

    public WebhookList(InvocationContext invocationContext, IFileManagementClient fileManagementClient) : base(
        invocationContext)
    {
        _fileManagementClient = fileManagementClient; 
    }

    [Webhook("On app mentioned", typeof(AppMentionedHandler),
        Description = "Triggered when the app is mentioned (@Blackbird)")]
    public async Task<WebhookResponse<GetMessageFilesResponse>> AppMentioned(WebhookRequest webhookRequest,
        [WebhookParameter] ChannelRequest input, [WebhookParameter] ThreadRequest thread)
    {
        var payload = JsonConvert.DeserializeObject<BasePayload<AppMentionedEvent>>(webhookRequest.Body.ToString());

        if (payload == null)
            throw new Exception("No serializable payload was found in incoming request.");

        var noFlightResponse = new WebhookResponse<GetMessageFilesResponse>
        {
            HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
            ReceivedWebhookRequestType = WebhookRequestType.Preflight
        };

        if (input.ChannelId != null && payload.Event.Channel != input.ChannelId)
            return noFlightResponse;

        var messageWithoutMentionedUser = Regex.Replace(payload.Event.Text, "<@.+> ", "");

        var message = await GetMessage(payload.Event.Channel, payload.Event.Ts);
        message.MessageText = messageWithoutMentionedUser;

        if (thread.ThreadTimestamp != null && thread.ThreadTimestamp != message?.ThreadTimestamp)
            return noFlightResponse;

        return new WebhookResponse<GetMessageFilesResponse>
        {
            HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
            Result = message,
            ReceivedWebhookRequestType = WebhookRequestType.Default,
        };
    }

    [Webhook("On message", typeof(ChannelMessageHandler), Description = "Triggered whenever any new message is posted")]
    public async Task<WebhookResponse<GetMessageFilesResponse>> ChannelMessage(WebhookRequest webhookRequest,
        [WebhookParameter] OnMessageWebhookParameter input, [WebhookParameter] ChannelRequest channel,
        [WebhookParameter] ThreadRequest thread)
    {
        var payload =
            JsonConvert.DeserializeObject<BasePayload<ChannelFileMessageEvent>>(webhookRequest.Body.ToString());

        if (payload == null)
            throw new Exception("No serializable payload was found in incoming request.");

        var noFlightResponse = new WebhookResponse<GetMessageFilesResponse>
        {
            HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
            ReceivedWebhookRequestType = WebhookRequestType.Preflight
        };

        if (channel.ChannelId != null && payload.Event.Channel != channel.ChannelId)
            return noFlightResponse;

        var message = await GetMessage(payload.Event.Channel, payload.Event.Ts);

        var isReply = message.ThreadTimestamp != null;

        if (input.ReplyHandling == "no_replies" && isReply)
            return noFlightResponse;

        if (input.ReplyHandling == "only_replies" && !isReply)
            return noFlightResponse;

        var hasFiles = message?.Files != null && message.Files.Any();

        if (input.TriggerOnlyOnFiles is true && !hasFiles)
            return noFlightResponse;

        if (thread.ThreadTimestamp != null && thread.ThreadTimestamp != message?.ThreadTimestamp)
            return noFlightResponse;

        return new WebhookResponse<GetMessageFilesResponse>
        {
            HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
            Result = message,
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
        [WebhookParameter] ChannelRequest input, [WebhookParameter] OptionalEmojiInput emoji,
        [WebhookParameter] MessageRequest messageInput)
    {
        var payload = JsonConvert.DeserializeObject<BasePayload<MessageReactionEvent>>(webhookRequest.Body.ToString());

        if (payload == null)
            throw new Exception("No serializable payload was found in incoming request.");

        var noFlightResponse = new WebhookResponse<ChannelMessageWithReaction>
        {
            HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
            ReceivedWebhookRequestType = WebhookRequestType.Preflight
        };

        if (input.ChannelId != null && payload.Event.Item.Channel != input.ChannelId)
            return noFlightResponse;

        if (emoji.Reactions != null && !emoji.Reactions.Contains(payload.Event.Reaction))
            return noFlightResponse;

        if (messageInput.MessageTimestamp != null && messageInput.MessageTimestamp != payload.Event.Item.Ts)
            return noFlightResponse;

        var message = await GetMessage(payload.Event.Item.Channel, payload.Event.Item.Ts);
        return new WebhookResponse<ChannelMessageWithReaction>
        {
            HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
            Result = new ChannelMessageWithReaction
            {
                ReactionUserId = payload.Event.User,
                Reaction = payload.Event.Reaction,
                Message = message,
            },
            ReceivedWebhookRequestType = WebhookRequestType.Default,
        };
    }

    private async Task<GetMessageFilesResponse> GetMessage(string channel, string timestamp)
    {
        var actions = new MessageActions(InvocationContext, _fileManagementClient);
        return await actions.GetMessageFiles(new ChannelRequest { ChannelId = channel }, new GetMessageParameters { Timestamp = timestamp });       
    }
}