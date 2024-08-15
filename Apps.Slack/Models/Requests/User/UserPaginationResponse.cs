using Apps.Slack.Models.Responses;
using Newtonsoft.Json;

namespace Apps.Slack.Models.Requests.User;

public class UserPaginationResponse : PaginationResponse<UserDto>
{
    [JsonProperty("members")]
    public override IEnumerable<UserDto> Items { get; set; }
}