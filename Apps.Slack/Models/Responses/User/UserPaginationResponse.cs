using Apps.Slack.Models.Entities;
using Newtonsoft.Json;

namespace Apps.Slack.Models.Responses.User;

public class UserPaginationResponse : PaginationResponse<UserEntity>
{
    [JsonProperty("members")]
    public override IEnumerable<UserEntity> Items { get; set; }
}