using Blackbird.Applications.Sdk.Common;

namespace Apps.Slack.Webhooks.Output;

public class ChannelMessage
{
    public string Message { get; set; }

    [Display("Channel ID")]
    public string Channel { get; set; }

    [Display("User ID")]
    public string User { get; set; }
    public string Timestamp { get; set; }
}