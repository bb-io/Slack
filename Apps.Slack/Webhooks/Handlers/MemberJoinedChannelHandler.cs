using Apps.Slack.Webhooks.Handlers.Base;

namespace Apps.Slack.Webhooks.Handlers;

public class MemberJoinedChannelHandler : BaseWebhookHandler
{
    const string SubscriptionEvent = "member_joined_channel";

    public MemberJoinedChannelHandler() : base(SubscriptionEvent) { }
}