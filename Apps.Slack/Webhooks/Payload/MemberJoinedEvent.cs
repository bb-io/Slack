using Blackbird.Applications.Sdk.Common;
using System.Text.Json.Serialization;

namespace Apps.Slack.Webhooks.Payload
{
    public class MemberJoinedEvent
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("user")]
        public string User { get; set; }

        [Display("Channel ID")]
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
