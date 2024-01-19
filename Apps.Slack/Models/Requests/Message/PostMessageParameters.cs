using Apps.Slack.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Files;

namespace Apps.Slack.Models.Requests.Message;

public class PostMessageParameters
{
    [Display("Channel ID")]
    [DataSource(typeof(ChannelHandler))]
    public string ChannelId { get; set; }

    [Display("Message")]
    public string Text { get; set; }
    
    public FileReference? Attachment { get; set; }

    [Display("Thread timestamp", Description = "If you are sending a message as part of a thread, set the timestamp of the primary message.")]
    public string? Timestamp { get; set; }
}