using Blackbird.Applications.Sdk.Common;
using System.Text.Json.Serialization;

namespace Apps.Slack.Dtos
{
    public class ChannelDto
    {
        [Display("Channel ID")]
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
