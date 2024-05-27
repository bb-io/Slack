using Apps.Slack.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Slack.Webhooks.Payload;

public class ChannelRequiredInputParameter
{
    [Display("Channel ID")]
    [DataSource(typeof(ChannelHandler))]
    public string ChannelId { get; set; }
}