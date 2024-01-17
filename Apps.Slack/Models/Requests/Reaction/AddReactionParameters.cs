using Apps.Slack.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Slack.Models.Requests.Reaction;

public class AddReactionParameters
{
    [Display("Channel ID")]
    [DataSource(typeof(ChannelHandler))]
    public string ChannelId { get; set; }
    public string Timestamp { get; set; }

    [DataSource(typeof(EmojiHandler))]
    public string Reaction { get; set; }
}