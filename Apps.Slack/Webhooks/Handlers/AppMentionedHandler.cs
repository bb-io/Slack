using Apps.Slack.Webhooks.Handlers.Base;

namespace Apps.Slack.Webhooks.Handlers;

public class AppMentionedHandler : BaseWebhookHandler
{
    const string SubscriptionEvent = "app_mention";

    public AppMentionedHandler() : base(SubscriptionEvent) { }
}