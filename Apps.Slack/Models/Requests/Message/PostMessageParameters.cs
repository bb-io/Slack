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
    
    public string? Text { get; set; }
    
    public FileReference? Attachment { get; set; }
}