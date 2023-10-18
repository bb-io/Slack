using Blackbird.Applications.Sdk.Common;

namespace Apps.Slack.Models.Requests.User;

public class GetUserProfileParameters
{
    [Display("User ID")]
    public string UserId { get; set; }
}