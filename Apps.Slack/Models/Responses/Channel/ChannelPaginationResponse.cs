using Apps.Slack.Models.Entities;
using Newtonsoft.Json;

namespace Apps.Slack.Models.Responses.Channel;

public class ChannelPaginationResponse : PaginationResponse<ChannelEntity>
{
    [JsonProperty("channels")]
    public override IEnumerable<ChannelEntity> Items { get; set; }
}