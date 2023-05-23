using Apps.Slack.Webhooks.Output;
using Apps.Slack.Webhooks.Payload;
using Blackbird.Applications.Sdk.Common.Webhooks;
using Newtonsoft.Json;
using System.Net;
using System.Text.RegularExpressions;

namespace Apps.Slack.Webhooks
{
    [WebhookList]
    public class WebhookList
    {
        [Webhook("On app mentioned", Description = "On app mentioned")]
        public async Task<WebhookResponse<AppMentionedEvent>> AppMentioned(WebhookRequest webhookRequest)
        {
            var payload = JsonConvert.DeserializeObject<AppMentionedPayload>(webhookRequest.Body.ToString());

            if (payload == null)
                throw new Exception("No serializable payload was found in inocming request.");

            // https://api.slack.com/events/url_verification
            if (payload.Type == "url_verification")
            {
                var response = new HttpResponseMessage();
                response.Content = new StringContent(payload.Challenge);
                return new WebhookResponse<AppMentionedEvent>
                {
                    HttpResponseMessage = response,
                    Result = null
                };
            }

            if (payload.Event.Type != "app_mention")
                throw new Exception("This event is not supported at the moment");

            var messageWithoutMentionedUser = Regex.Replace(payload.Event.Text, "<@.+> ", "");

            return new WebhookResponse<AppMentionedEvent>
            {
                HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
                Result = new AppMentionedEvent
                {
                    User = payload.Event.User,
                    Channel = payload.Event.Channel,
                    Message = messageWithoutMentionedUser
                }
            };

        }
    }
}
