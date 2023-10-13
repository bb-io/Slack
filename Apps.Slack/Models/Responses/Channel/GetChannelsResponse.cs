using System.Text.Json.Serialization;
using Apps.Slack.Models.Entities;

namespace Apps.Slack.Models.Responses.Channel;

public class GetChannelsResponse
{
    [JsonPropertyName("channels")]
    public IEnumerable<ChannelEntity> Channels { get; set; }
}