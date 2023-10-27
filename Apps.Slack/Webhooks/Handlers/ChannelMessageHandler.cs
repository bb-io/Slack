using Apps.Slack.Webhooks.Handlers.Base;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.Slack.Webhooks.Handlers;

public class ChannelMessageHandler : BaseWebhookHandler
{
    const string SubscriptionEvent = "message.channels";

    public ChannelMessageHandler(InvocationContext invocationContext) : base(invocationContext, SubscriptionEvent) { }
}