using Apps.Slack.Webhooks.Handlers;
using Apps.Slack.Webhooks.Output;
using Apps.Slack.Webhooks.Payload;
using Blackbird.Applications.Sdk.Common.Webhooks;
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
    }
}
