using Blackbird.Applications.Sdk.Common;

namespace Apps.Slack.Models.Requests.Message;

public class DeleteMessageParameters
{
    [Display("Timestamp")]
    public string Ts { get; set; }
}