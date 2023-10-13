using Apps.Slack.Models.Entities;

namespace Apps.Slack.Models.Responses.User;

public class GetUserByEmailResponse
{
    public UserEntity User { get; set; }
}