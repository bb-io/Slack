using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Apps.Slack.Webhooks.Payload
{
    public class ChannelMessageEvent
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
