using Apps.Slack.Models.Entities;
using Newtonsoft.Json;

namespace Apps.Slack.Models.Responses.Channel;

public class GetChannelsResponse
{
    [JsonProperty("channels")]
    public IEnumerable<ChannelEntity> Channels { get; set; }
}