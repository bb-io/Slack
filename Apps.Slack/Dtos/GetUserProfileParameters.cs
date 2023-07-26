using Blackbird.Applications.Sdk.Common;

namespace Apps.Slack.Dtos
{
    public class GetUserProfileParameters
    {
        [Display("User ID")]
        public string UserId { get; set; }
    }
}
