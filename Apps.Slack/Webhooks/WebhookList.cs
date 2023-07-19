using Apps.Slack.Webhooks.Handlers;
using Apps.Slack.Webhooks.Output;
using Apps.Slack.Webhooks.Payload;
using Blackbird.Applications.Sdk.Common.Webhooks;
using RestSharp;
using System;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Apps.Slack.Webhooks
{
    [WebhookList]
    public class WebhookList
    {
        [Webhook("On app mentioned", typeof(AppMentionedHandler), Description = "On app mentioned")]
        public async Task<WebhookResponse<ChannelMessage>> AppMentioned(WebhookRequest webhookRequest)
        {
            var payload = JsonSerializer.Deserialize<BasePayload<AppMentionedEvent>>(webhookRequest.Body.ToString());

            if (payload == null)
                throw new Exception("No serializable payload was found in inocming request.");

            var messageWithoutMentionedUser = Regex.Replace(payload.Event.Text, "<@.+> ", "");

            return new WebhookResponse<ChannelMessage>
            {
                HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
                Result = new ChannelMessage
                {
                    User = payload.Event.User,
                    Channel = payload.Event.Channel,
                    Message = messageWithoutMentionedUser,
                    Timestamp = payload.Event.Ts
                }
            };
        }

        [Webhook("On channel message", typeof(ChannelMessageHandler), Description = "On channel message")]
        public async Task<WebhookResponse<ChannelMessage>> ChannelMessage(WebhookRequest webhookRequest)
        {
            var payload = JsonSerializer.Deserialize<BasePayload<ChannelMessageEvent>>(webhookRequest.Body.ToString());

            if (payload == null)
                throw new Exception("No serializable payload was found in inocming request.");

            return new WebhookResponse<ChannelMessage>
            {
                HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
                Result = new ChannelMessage
                {
                    User = payload.Event.User,
                    Channel = payload.Event.Channel,
                    Message = payload.Event.Text,
                    Timestamp = payload.Event.Ts
                }
            };
        }

        [Webhook("On channel files message", typeof(ChannelMessageHandler), Description = "On channel files message")]
        public async Task<WebhookResponse<ChannelFilesMessage>> ChannelFilesMessage(WebhookRequest webhookRequest)
        {
            var payload = JsonSerializer.Deserialize<BasePayload<ChannelFileMessageEvent>>(webhookRequest.Body.ToString());

            if (payload == null)
                throw new Exception("No serializable payload was found in inocming request.");
            if (payload.Event.Files is null)
                return new WebhookResponse<ChannelFilesMessage>() { 
                    HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
                    ReceivedWebhookRequestType = WebhookRequestType.Preflight
                };

            return new WebhookResponse<ChannelFilesMessage>
            {
                HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
                Result = new ChannelFilesMessage
                {
                    User = payload.Event.User,
                    Channel = payload.Event.Channel,
                    Message = payload.Event.Text,
                    Timestamp = payload.Event.Ts,
                    Files = payload.Event.Files.Select(f => new OutputMessageFile() 
                    { 
                        Id = f.Id,
                        Name = f.Name,
                        Url = f.UrlPrivate,
                        FileType = f.Filetype
                    }).ToList()
                }
            };
        }

        [Webhook("On member joined channel", typeof(MemberJoinedChannelHandler), Description = "On member joined channel")]
        public async Task<WebhookResponse<MemberJoinedEvent>> MemberJoinedChannel(WebhookRequest webhookRequest)
        {
            var payload = JsonSerializer.Deserialize<BasePayload<MemberJoinedEvent>>(webhookRequest.Body.ToString());

            if (payload == null)
                throw new Exception("No serializable payload was found in inocming request.");

            return new WebhookResponse<MemberJoinedEvent>
            {
                HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
                Result = payload.Event,
            };
        }

        [Webhook("On message reaction", typeof(MessageReactionHandler), Description = "On any message reaction")]
        public async Task<WebhookResponse<MessageReactionEvent>> MessageReaction(WebhookRequest webhookRequest)
        {
            var payload = JsonSerializer.Deserialize<BasePayload<MessageReactionEvent>>(webhookRequest.Body.ToString());

            if (payload == null)
                throw new Exception("No serializable payload was found in inocming request.");

            return new WebhookResponse<MessageReactionEvent>
            {
                HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
                Result = payload.Event,
            };
        }

        private byte[] DownloadFileByUrl(string url)
        {
            var client = new RestClient();
            var request = new RestRequest(url, Method.Get);
            return client.Get(request).RawBytes;
        }
    }
}
