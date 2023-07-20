using Blackbird.Applications.Sdk.Common;
using System.Text.Json.Serialization;

namespace Apps.Slack.Webhooks.Payload
{
    public class AppMentionedEvent
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("user")]
        public string User { get; set; }
        [JsonPropertyName("text")]
        public string Text { get; set; }

        [Display("Timestamp")]
        [JsonPropertyName("ts")]
        public string Ts { get; set; }
        [JsonPropertyName("channel")]

        [Display("Channel ID")]
        public string Channel { get; set; }

        [Display("Event timestamp")]
        [JsonPropertyName("event_ts")]
        public string EventTs { get; set; }
    }
}
