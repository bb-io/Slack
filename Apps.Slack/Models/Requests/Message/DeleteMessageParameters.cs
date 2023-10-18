using Apps.Slack.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Slack.Models.Requests.Message;

public class DeleteMessageParameters
{
    [Display("Channel ID")]
    [DataSource(typeof(ChannelHandler))]
    public string ChannelId { get; set; }

    [Display("Timestamp")]
    public string Ts { get; set; }
}