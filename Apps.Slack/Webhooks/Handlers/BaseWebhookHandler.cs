using Apps.Slack.Webhooks.Bridge;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Webhooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Slack.Webhooks.Handlers
{
    public class BaseWebhookHandler : IWebhookEventHandler
    {
        private string SubscriptionEvent;
        public BaseWebhookHandler(string subEvent)
        {
            SubscriptionEvent = subEvent;
        }

        public async Task SubscribeAsync(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders, Dictionary<string, string> values)
        {
            var bridge = new BridgeService(authenticationCredentialsProviders);
            bridge.Subscribe(SubscriptionEvent, values["payloadUrl"]);
        }

        public async Task UnsubscribeAsync(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders, Dictionary<string, string> values)
        {
            var bridge = new BridgeService(authenticationCredentialsProviders);
            bridge.Unsubscribe(SubscriptionEvent);
        }

    }
}
