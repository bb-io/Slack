using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Apps.Slack.Webhooks.Payload
{
    public class AppMentionedPayload
    {
        public string Token { get; set; }

        [JsonProperty("team_id")]
        public string TeamId { get; set; }

        [JsonProperty("api_app_id")]
        public string ApiAppId { get; set; }

        public Event Event { get; set; }
        public string Type { get; set; }

        [JsonProperty("event_id")]
        public string EventId { get; set; }

        [JsonProperty("event_time")]
        public long EventTime { get; set; }

        [JsonProperty("authed_users")]
        public string AuthedUsers { get; set; }
        public string Challenge { get; set; }
    }

    public class Event
    {
        public string Type { get; set; }
        public string User { get; set; }
        public string Text { get; set; }
        public string Ts { get; set; }
        public string Channel { get; set; }

        [JsonProperty("event_ts")]
        public string EventTs { get; set; }
    }
}
