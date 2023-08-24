using Apps.Slack.Dtos;
using System.Text.Json.Serialization;

namespace Apps.Slack.Models.Responses
{
    public class GetUsersResponse
    {
        [JsonPropertyName("members")]
        public IEnumerable<UserInfoDto> Members { get; set; }
    }
}
