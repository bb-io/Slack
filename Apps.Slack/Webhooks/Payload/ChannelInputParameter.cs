using Apps.Slack.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Slack.Webhooks.Payload;

public class ChannelInputParameter
{
    [Display("Channel ID")]
    [DataSource(typeof(ChannelHandler))]
    public string? ChannelId { get; set; }
}