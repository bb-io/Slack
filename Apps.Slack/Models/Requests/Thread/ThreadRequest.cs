using Apps.Slack.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Slack.Models.Requests.Thread
{
    public class ThreadRequest
    {
        [Display("Thread timestamp", Description = "To filter messages only if they are part of a thread, use the message timestamp of the top thread message.")]
        public string? ThreadTimestamp { get; set; }
    }
}
