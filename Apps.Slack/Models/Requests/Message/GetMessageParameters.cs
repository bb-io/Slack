using Apps.Slack.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Slack.Models.Requests.Message;

public class GetMessageParameters
{
    public string Timestamp { get; set; }

        
    [Display("Channel ID")]
    [DataSource(typeof(ChannelHandler))]
    public string ChannelId { get; set; }
}