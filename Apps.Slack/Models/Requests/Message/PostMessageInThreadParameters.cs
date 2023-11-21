using Blackbird.Applications.Sdk.Common;

namespace Apps.Slack.Models.Requests.Message;

public class PostMessageInThreadParameters : PostMessageParameters
{
    [Display("Channel message timestamp")]
    public string Timestamp { get; set; }
}