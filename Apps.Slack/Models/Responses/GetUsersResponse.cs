using Apps.Slack.Dtos;

namespace Apps.Slack.Models.Responses
{
    public class GetUsersResponse
    {
        public UserInfoDto[] Members { get; set; }
    }
}
