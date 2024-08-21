using Apps.Slack.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Slack.Models.Requests.Channel;

public class ChannelRequest
{
    [Display("Channel ID")]
    [DataSource(typeof(ChannelHandler))]
    public string? ChannelId { get; set; }
    
    [Display("Manual channel ID")]
    public string? ManualChannelId { get; set; }
}