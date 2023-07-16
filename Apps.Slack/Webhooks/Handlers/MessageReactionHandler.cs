using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Slack.Webhooks.Handlers
{
    public class MessageReactionHandler : BaseWebhookHandler
    {
        const string SubscriptionEvent = "reaction_added";

        public MessageReactionHandler() : base(SubscriptionEvent) { }
    }
}
