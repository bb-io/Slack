using Blackbird.Applications.Sdk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Apps.Slack.Webhooks.Payload
{
    public class MemberJoinedEvent
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("user")]
        public string User { get; set; }

        [JsonPropertyName("channel")]
        public string Channel { get; set; }
        [Display("Channel Type")]
        [JsonPropertyName("channel_Type")]
        public string ChannelType { get; set; }
        [JsonPropertyName("team")]
        public string Team { get; set; }
        [JsonPropertyName("inviter")]
        public string Inviter { get; set; }

    }
}
