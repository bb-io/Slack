using Blackbird.Applications.Sdk.Common;

namespace Apps.Slack.Dtos
{
    public class GetUserInfoParameters
    {
        [Display("User ID")]
        public string UserId { get; set; }
    }
}
