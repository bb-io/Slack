using Apps.Slack.Webhooks.Handlers.Base;

namespace Apps.Slack.Webhooks.Handlers;

public class MessageReactionHandler : BaseWebhookHandler
{
    const string SubscriptionEvent = "reaction_added";

    public MessageReactionHandler() : base(SubscriptionEvent) { }
}