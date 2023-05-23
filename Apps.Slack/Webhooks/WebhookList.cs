using Apps.Slack.Webhooks.Payload;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Slack.Webhooks
{
    [WebhookList]
    public class WebhookList
    {
        [Webhook("On app mentioned", Description = "On app mentioned")]
        public async Task<WebhookResponse<Event>> AppMentioned(WebhookRequest webhookRequest)
        {
            var payload = webhookRequest.Body as AppMentionedPayload;
            return new WebhookResponse<Event>
            {
                Result = payload?.Event
            };
        }
    }
}
