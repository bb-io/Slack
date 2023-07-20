using Blackbird.Applications.Sdk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Apps.Slack.Webhooks.Payload
{
    public class MessageReactionEvent
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
        public MessageItem Item { get; set; }
    }

    public class MessageItem
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [Display("Channel ID")]
        [JsonPropertyName("channel")]
        public string Channel { get; set; }

        [Display("Message timestamp")]
        [JsonPropertyName("ts")]
        public string Ts { get; set; }
    }
}
