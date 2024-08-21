using Blackbird.Applications.Sdk.Common;

namespace Apps.Slack.Models.Requests.Message;

public class GetMessageParameters
{
    [Display("Message timestamp")]
    public string Timestamp { get; set; }
}