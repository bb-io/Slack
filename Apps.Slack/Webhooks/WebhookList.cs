using Apps.Slack.Webhooks.Handlers;
using Apps.Slack.Webhooks.Payload;
using Blackbird.Applications.Sdk.Common.Webhooks;
using System.Text.Json;

namespace Apps.Slack.Webhooks
{
    [WebhookList]
    public class WebhookList
    {
        [Webhook("On app mentioned", typeof(AppMentionedHandler), Description = "On app mentioned")]
        public async Task<WebhookResponse<Event>> AppMentioned(WebhookRequest webhookRequest)
        {
            var payload = JsonSerializer.Deserialize<AppMentionedPayload>(webhookRequest.Body.ToString());
            return new WebhookResponse<Event>
            {
                Result = payload?.Event
            };
        }
    }
}
