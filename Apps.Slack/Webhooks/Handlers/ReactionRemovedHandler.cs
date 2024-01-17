using Apps.Slack.Webhooks.Handlers.Base;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.Slack.Webhooks.Handlers;

public class ReactionRemovedHandler : BaseWebhookHandler
{
    const string SubscriptionEvent = "reaction_removed";

    public ReactionRemovedHandler(InvocationContext invocationContext) : base(invocationContext, SubscriptionEvent) { }
}