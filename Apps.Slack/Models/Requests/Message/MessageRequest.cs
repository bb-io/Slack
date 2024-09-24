using Blackbird.Applications.Sdk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Slack.Models.Requests.Message
{
    public class MessageRequest
    {
        [Display("Message timestamp", Description = "Filter on a specific message.")]
        public string? MessageTimestamp { get; set; }
    }
}
