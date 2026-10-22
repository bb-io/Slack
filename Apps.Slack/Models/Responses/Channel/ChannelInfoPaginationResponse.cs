using Apps.Slack.Models.Entities;
using Newtonsoft.Json;

namespace Apps.Slack.Models.Responses.Channel;

public class ChannelInfoPaginationResponse : PaginationResponse<ChannelInfoEntity>
{
    [JsonProperty("channels")]
    public override IEnumerable<ChannelInfoEntity> Items { get; set; } = Array.Empty<ChannelInfoEntity>();
}
