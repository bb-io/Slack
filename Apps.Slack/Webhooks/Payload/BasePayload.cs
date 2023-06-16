using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Apps.Slack.Webhooks.Payload
{
    public class BasePayload<T>
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("team_id")]
        public string TeamId { get; set; }

        [JsonPropertyName("api_app_id")]
        public string ApiAppId { get; set; }

        [JsonPropertyName("event")]
        public T Event { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("event_id")]
        public string EventId { get; set; }

        [JsonPropertyName("event_time")]
        public long EventTime { get; set; }

        [JsonPropertyName("authed_users")]
        public string AuthedUsers { get; set; }
        [JsonPropertyName("challenge")]
        public string Challenge { get; set; }
    }
}
