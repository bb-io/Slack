using Apps.Slack.Models.Entities;
using Newtonsoft.Json;

namespace Apps.Slack.Models.Responses.User;

public class GetUsersResponse
{
    [JsonProperty("members")]
    public IEnumerable<UserEntity> Members { get; set; }
}