using Apps.Slack.Dtos;
using System.Text.Json.Serialization;

namespace Apps.Slack.Models.Responses
{
    public class GetChannelsResponse
    {
        [JsonPropertyName("channels")]
        public IEnumerable<ChannelDto> Channels { get; set; }
    }
}
