using Blackbird.Applications.Sdk.Common;

namespace Apps.Slack.Models.Requests.Reaction;

public class DeleteReactionRequest
{
    [Display("Channel ID")]
    public string Channel { get; set; }
    public string Timestamp { get; set; }
    public string Name { get; set; }
}