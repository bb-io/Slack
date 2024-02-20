using Blackbird.Applications.Sdk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Slack.Models.Responses.Message
{
    public class GetMessageResponse
    {
        [Display("Message")]
        public string? MessageText { get; set; }

        [Display("User ID")]
        public string User { get; set; }

        [Display("Message timestamp")]
        public string Timestamp { get; set; }

        [Display("Thread timestamp")]
        public string ThreadTimestamp { get; set; }

        [Display("Channel ID")]
        public string ChannelId { get; set; }

        [Display("Is thread reply?")]
        public bool IsThreadReply => Timestamp != ThreadTimestamp;

        [Display("Has attachments?")]
        public bool HasAttachments { get; set; }
    }
}
