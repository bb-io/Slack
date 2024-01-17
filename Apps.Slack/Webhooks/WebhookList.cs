using Apps.Slack.Webhooks.Handlers;
using Apps.Slack.Webhooks.Output;
using Apps.Slack.Webhooks.Payload;
using Blackbird.Applications.Sdk.Common.Webhooks;
using System.Net;
using System.Text.RegularExpressions;
using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.SDK.Extensions.FileManagement.Interfaces;
using Apps.Slack.Actions;

namespace Apps.Slack.Webhooks;

[WebhookList]
public class WebhookList : BaseInvocable
{
    private IFileManagementClient FileManagementClient { get; set; }
    public WebhookList(InvocationContext invocationContext, IFileManagementClient fileManagementClient) : base(invocationContext)
    {
        FileManagementClient = fileManagementClient;
    }

    [Webhook("On app mentioned", typeof(AppMentionedHandler), Description = "On app mentioned")]
    public Task<WebhookResponse<ChannelMessage>> AppMentioned(WebhookRequest webhookRequest, [WebhookParameter] ChannelInputParameter input)
    {
        var payload = JsonConvert.DeserializeObject<BasePayload<AppMentionedEvent>>(webhookRequest.Body.ToString());

        if (payload == null)
            throw new Exception("No serializable payload was found in incoming request.");

        if (input.ChannelId != null && payload.Event.Channel != input.ChannelId)
            return Task.FromResult(new WebhookResponse<ChannelMessage> { HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK), ReceivedWebhookRequestType = WebhookRequestType.Preflight });

        var messageWithoutMentionedUser = Regex.Replace(payload.Event.Text, "<@.+> ", "");

        return Task.FromResult(new WebhookResponse<ChannelMessage>
        {
            HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
            Result = new ChannelMessage
            {
                User = payload.Event.User,
                Channel = payload.Event.Channel,
                Message = messageWithoutMentionedUser,
                Timestamp = payload.Event.Ts
            }
        });
    }

    [Webhook("On channel message", typeof(ChannelMessageHandler), Description = "On channel message")]
    public Task<WebhookResponse<ChannelMessage>> ChannelMessage(WebhookRequest webhookRequest, [WebhookParameter] ChannelInputParameter input, 
        [WebhookParameter] [Display("Trigger on message replies")] bool? triggerOnMessageReplies)
    {
        var payload = JsonConvert.DeserializeObject<BasePayload<ChannelMessageEvent>>(webhookRequest.Body.ToString());

        if (payload == null)
            throw new Exception("No serializable payload was found in incoming request.");

        if (input.ChannelId != null && payload.Event.Channel != input.ChannelId)
            return Task.FromResult(new WebhookResponse<ChannelMessage> { HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK), ReceivedWebhookRequestType = WebhookRequestType.Preflight });
            
        if (payload.Event.ThreadTs != null && !(triggerOnMessageReplies ?? false))
            return Task.FromResult(new WebhookResponse<ChannelMessage> { HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK), ReceivedWebhookRequestType = WebhookRequestType.Preflight });

        return Task.FromResult(new WebhookResponse<ChannelMessage>
        {
            HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
            Result = new ChannelMessage
            {
                User = payload.Event.User,
                Channel = payload.Event.Channel,
                Message = payload.Event.Text,
                Timestamp = payload.Event.Ts
            }
        });
    }

    [Webhook("On channel files message", typeof(ChannelMessageHandler), Description = "On channel files message")]
    public Task<WebhookResponse<ChannelFilesMessage>> ChannelFilesMessage(WebhookRequest webhookRequest, [WebhookParameter] ChannelInputParameter input,
        [WebhookParameter] [Display("Trigger on message replies")] bool? triggerOnMessageReplies)
    {
        var payload = JsonConvert.DeserializeObject<BasePayload<ChannelFileMessageEvent>>(webhookRequest.Body.ToString());

        if (payload == null)
            throw new Exception("No serializable payload was found in incoming request.");
            
        if (payload.Event.Files is null)
            return Task.FromResult(new WebhookResponse<ChannelFilesMessage>() { HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK), ReceivedWebhookRequestType = WebhookRequestType.Preflight });
            
        if (input.ChannelId != null && payload.Event.Channel != input.ChannelId)
            return Task.FromResult(new WebhookResponse<ChannelFilesMessage> { HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK), ReceivedWebhookRequestType = WebhookRequestType.Preflight });
            
        if (payload.Event.ThreadTs != null && !(triggerOnMessageReplies ?? false))
            return Task.FromResult(new WebhookResponse<ChannelFilesMessage> { HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK), ReceivedWebhookRequestType = WebhookRequestType.Preflight });

        FileActions fileActions = new FileActions(InvocationContext, FileManagementClient);
        var filesData = payload.Event.Files.Select(f => new OutputMessageFile()
        {
            Id = f.Id,
            Name = f.Name,
            Url = f.UrlPrivate,
            FileType = f.Filetype,
            File = fileActions.DownloadFile(new Models.Requests.File.DownloadFileRequest() { Url = f.UrlPrivate }).File,
        }).ToList();

        return Task.FromResult(new WebhookResponse<ChannelFilesMessage>
        {
            HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
            Result = new ChannelFilesMessage
            {
                User = payload.Event.User,
                Channel = payload.Event.Channel,
                Message = payload.Event.Text,
                Timestamp = payload.Event.Ts,
                Files = filesData
                //Files = payload.Event.Files.Select(f => new OutputMessageFile() 
                //{ 
                //    Id = f.Id,
                //    Name = f.Name,
                //    Url = f.UrlPrivate,
                //    FileType = f.Filetype
                //}).ToList()
            }
        });
    }

    [Webhook("On member joined channel", typeof(MemberJoinedChannelHandler), Description = "On member joined channel")]
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

    [Webhook("On message reaction", typeof(MessageReactionHandler), Description = "On any message reaction")]
    public Task<WebhookResponse<MessageReactionEvent>> MessageReaction(WebhookRequest webhookRequest, [WebhookParameter] ChannelInputParameter input)
    {
        var payload = JsonConvert.DeserializeObject<BasePayload<MessageReactionEvent>>(webhookRequest.Body.ToString());

        if (payload == null)
            throw new Exception("No serializable payload was found in incoming request.");
            
        if (input.ChannelId != null && payload.Event.Item.Channel != input.ChannelId)
            return Task.FromResult(new WebhookResponse<MessageReactionEvent> { HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK), ReceivedWebhookRequestType = WebhookRequestType.Preflight });

        return Task.FromResult(new WebhookResponse<MessageReactionEvent>
        {
            HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
            Result = payload.Event,
        });
    }
}