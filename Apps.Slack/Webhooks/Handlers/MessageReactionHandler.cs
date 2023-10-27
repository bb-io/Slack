using Apps.Slack.Webhooks.Handlers.Base;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.Slack.Webhooks.Handlers;

public class MessageReactionHandler : BaseWebhookHandler
{
    const string SubscriptionEvent = "reaction_added";

    public MessageReactionHandler(InvocationContext invocationContext) : base(invocationContext, SubscriptionEvent) { }
}