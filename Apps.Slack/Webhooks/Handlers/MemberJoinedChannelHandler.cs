using Apps.Slack.Webhooks.Handlers.Base;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Slack.Webhooks.Handlers;

public class MemberJoinedChannelHandler : BaseInvocable, IWebhookEventHandler
{
    const string SubscriptionEvent = "member_joined_channel";

    public MemberJoinedChannelHandler(InvocationContext invocationContext) : base(invocationContext) { }

    public Task SubscribeAsync(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProvider, Dictionary<string, string> values)
    {
        return BaseWebhookHandler.SubscribeAsync(authenticationCredentialsProvider, values, $"{InvocationContext.UriInfo.BridgeServiceUrl.ToString().TrimEnd('/')}/slack", SubscriptionEvent);
    }

    public Task UnsubscribeAsync(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProvider, Dictionary<string, string> values)
    {
        return BaseWebhookHandler.UnsubscribeAsync(authenticationCredentialsProvider, values, $"{InvocationContext.UriInfo.BridgeServiceUrl.ToString().TrimEnd('/')}/slack", SubscriptionEvent);
    }
}