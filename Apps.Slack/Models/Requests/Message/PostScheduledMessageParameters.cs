using Blackbird.Applications.Sdk.Common;

namespace Apps.Slack.Models.Requests.Message;

public class PostScheduledMessageParameters : PostMessageParameters
{
    [Display("Post at")]
    public DateTime PostAt { get; set; }
}