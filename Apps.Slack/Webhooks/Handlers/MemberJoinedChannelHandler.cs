using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Slack.Webhooks.Handlers
{
    public class MemberJoinedChannelHandler : BaseWebhookHandler
    {
        const string SubscriptionEvent = "member_joined_channel";

        public MemberJoinedChannelHandler() : base(SubscriptionEvent) { }
    }
}
