using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Slack.Webhooks.Handlers
{
    public class ChannelMessageHandler : BaseWebhookHandler
    {
        const string SubscriptionEvent = "message.channels";

        public ChannelMessageHandler() : base(SubscriptionEvent) { }
    }
}
