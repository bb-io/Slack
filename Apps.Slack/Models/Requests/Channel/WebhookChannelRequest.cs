using Apps.Slack.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Slack.Models.Requests.Channel;

public class WebhookChannelRequest
{
    [Display("Channel IDs", Description = "If empty, triggers for mentions from any channel where the app is installed.")]
    [DataSource(typeof(ChannelHandler))]
    public IEnumerable<string>? ChannelIds { get; set; }
}
