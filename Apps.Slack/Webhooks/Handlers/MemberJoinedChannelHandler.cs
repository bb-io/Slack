using Apps.Slack.Webhooks.Handlers.Base;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.Slack.Webhooks.Handlers;

public class MemberJoinedChannelHandler : BaseWebhookHandler
{
    const string SubscriptionEvent = "member_joined_channel";

    public MemberJoinedChannelHandler(InvocationContext invocationContext) : base(invocationContext, SubscriptionEvent) { }
}