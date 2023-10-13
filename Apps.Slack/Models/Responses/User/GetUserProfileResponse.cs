using Apps.Slack.Models.Entities;

namespace Apps.Slack.Models.Responses.User;

public class GetUserProfileResponse
{
    public UserProfileEntity Profile { get; set; }
}