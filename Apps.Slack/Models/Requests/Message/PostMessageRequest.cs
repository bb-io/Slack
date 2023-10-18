using Blackbird.Applications.Sdk.Common;

namespace Apps.Slack.Models.Requests.Message;

public class PostMessageRequest
{
    public string Text { get; set; }

    [Display("Channel ID")]
    public string Channel { get; set; }
}