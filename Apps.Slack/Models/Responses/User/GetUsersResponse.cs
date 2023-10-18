using System.Text.Json.Serialization;
using Apps.Slack.Models.Entities;

namespace Apps.Slack.Models.Responses.User;

public class GetUsersResponse
{
    [JsonPropertyName("members")]
    public IEnumerable<UserEntity> Members { get; set; }
}