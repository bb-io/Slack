using Blackbird.Applications.Sdk.Common;

namespace Apps.Slack.Models.Requests.Message;

public class DeleteMessageRequest
{
    [Display("Channel ID")]
    public string Channel { get; set; }

    [Display("Timestamp")]
    public string Ts { get; set; }
}