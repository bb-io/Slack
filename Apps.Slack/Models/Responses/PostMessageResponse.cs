using Blackbird.Applications.Sdk.Common;
using System.Text.Json.Serialization;

namespace Apps.Slack.Models.Responses
{
    public class PostMessageResponse
    {
        [Display("Channel ID")]
        [JsonPropertyName("channel")]
        public string Channel { get; set; }

        [Display("Message timestamp")]
        [JsonPropertyName("ts")]
        public string Timestamp { get; set; }
    }
}
