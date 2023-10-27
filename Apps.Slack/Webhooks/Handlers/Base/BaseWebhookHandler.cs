using Apps.Slack.Webhooks.Bridge;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Slack.Webhooks.Handlers.Base;

public static class BaseWebhookHandler 
{

    public static Task SubscribeAsync(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders, Dictionary<string, string> values, string bridgeUrl, string subscriptionEvent)
    {
        var bridge = new BridgeService(authenticationCredentialsProviders);
        bridge.Subscribe(subscriptionEvent, values["payloadUrl"], bridgeUrl);
      
        return Task.CompletedTask;
    }

    public static Task UnsubscribeAsync(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders, Dictionary<string, string> values, string bridgeUrl, string subscriptionEvent)
    {
        var bridge = new BridgeService(authenticationCredentialsProviders);
        bridge.Unsubscribe(subscriptionEvent, values["payloadUrl"], bridgeUrl);
       
        return Task.CompletedTask;
    }

}