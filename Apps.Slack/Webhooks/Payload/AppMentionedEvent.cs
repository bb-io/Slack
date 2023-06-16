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
        [JsonPropertyName("ts")]
        public string Ts { get; set; }
        [JsonPropertyName("channel")]
        public string Channel { get; set; }
        [JsonPropertyName("event_ts")]
        public string EventTs { get; set; }
    }
}
