using Blackbird.Applications.Sdk.Common;
using System.Text.Json.Serialization;

namespace Apps.Slack.Webhooks.Payload
{
    public class BasePayload<T>
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }

        [Display("Team ID")]
        [JsonPropertyName("team_id")]
        public string TeamId { get; set; }

        [Display("Api app ID")]
        [JsonPropertyName("api_app_id")]
        public string ApiAppId { get; set; }

        [JsonPropertyName("event")]
        public T Event { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [Display("Event ID")]
        [JsonPropertyName("event_id")]
        public string EventId { get; set; }

        [Display("Event time")]
        [JsonPropertyName("event_time")]
        public long EventTime { get; set; }

        [Display("Authed users")]
        [JsonPropertyName("authed_users")]
        public string AuthedUsers { get; set; }
        [JsonPropertyName("challenge")]
        public string Challenge { get; set; }
    }
}
