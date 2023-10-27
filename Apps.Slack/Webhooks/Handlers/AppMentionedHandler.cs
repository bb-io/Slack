using Apps.Slack.Webhooks.Handlers.Base;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.Slack.Webhooks.Handlers;

public class AppMentionedHandler : BaseWebhookHandler
{
    const string SubscriptionEvent = "app_mention";

    public AppMentionedHandler(InvocationContext invocationContext) : base(invocationContext, SubscriptionEvent) { }
}