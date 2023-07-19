using Blackbird.Applications.Sdk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Apps.Slack.Webhooks.Payload
{
    public class FileMessageReactionEvent
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("user")]
        public string User { get; set; }

        [JsonPropertyName("reaction")]
        public string Reaction { get; set; }

        [Display("Item user")]
        [JsonPropertyName("item_user")]
        public string ItemUser { get; set; }

        [Display("Event timestamp")]
        [JsonPropertyName("event_ts")]
        public string EventTs { get; set; }

        [JsonPropertyName("item")]
        public EmbeddedFileInfo Item { get; set; }
    }

    public class EmbeddedFileInfo
    {

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("channel")]
        public string Channel { get; set; }

        [JsonPropertyName("ts")]
        public string Ts { get; set; }
    }
}
