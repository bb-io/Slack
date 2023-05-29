using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Slack.Webhooks.Handlers
{
    public class AppMentionedHandler : BaseWebhookHandler
    {
        const string SubscriptionEvent = "app_mention";

        public AppMentionedHandler() : base(SubscriptionEvent) { }
    }
}
