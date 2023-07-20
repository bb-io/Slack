using Blackbird.Applications.Sdk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Slack.Models.Requests
{
    public class GetMessageParameters
    {
        public string Timestamp { get; set; }

        [Display("Channel ID")]
        public string ChannelId { get; set; }
    }
}
