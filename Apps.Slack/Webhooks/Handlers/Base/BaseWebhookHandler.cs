using Apps.Slack.Webhooks.Bridge;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Slack.Webhooks.Handlers.Base;

public class BaseWebhookHandler : IWebhookEventHandler
{
    private readonly string _subscriptionEvent;
    public BaseWebhookHandler(string subEvent)
    {
        _subscriptionEvent = subEvent;
    }

    public Task SubscribeAsync(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders, Dictionary<string, string> values)
    {
        var bridge = new BridgeService(authenticationCredentialsProviders);
        bridge.Subscribe(_subscriptionEvent, values["payloadUrl"]);
      
        return Task.CompletedTask;
    }

    public Task UnsubscribeAsync(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders, Dictionary<string, string> values)
    {
        var bridge = new BridgeService(authenticationCredentialsProviders);
        bridge.Unsubscribe(_subscriptionEvent, values["payloadUrl"]);
       
        return Task.CompletedTask;
    }

}