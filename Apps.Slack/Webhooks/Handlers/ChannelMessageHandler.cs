using Apps.Slack.Webhooks.Handlers.Base;
using Apps.Slack.Webhooks.Payload;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Slack.Webhooks.Handlers;

public class ChannelMessageHandler : BaseWebhookHandler
{
    private const string PublicChannelEvent = "message.channels";
    private const string PrivateChannelEvent = "message.groups";

    public ChannelMessageHandler(InvocationContext invocationContext,
        [WebhookParameter] OnMessageWebhookParameter parameter)
        : base(invocationContext, parameter.IsPrivateChannel == true ? PrivateChannelEvent : PublicChannelEvent)
    {
    }
}