using Apps.Slack.Webhooks.Handlers.Base;
using Apps.Slack.Webhooks.Payload;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Slack.Webhooks.Handlers;

public class ChannelMessageHandler : BaseWebhookHandler
{
    const string SubscriptionEvent = "message.channels";

    public ChannelMessageHandler(InvocationContext invocationContext,
        [WebhookParameter] OnMessageWebhookParameter parameter) : base(invocationContext, SubscriptionEvent)
    {
    }
}