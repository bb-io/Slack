using Apps.Slack.DynamicHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Slack.Webhooks.Payload
{
    public class ChannelInputParameter
    {
        [Display("Channel ID")]
        [DataSource(typeof(ChannelHandler))]
        public string? ChannelId { get; set; }
    }
}
