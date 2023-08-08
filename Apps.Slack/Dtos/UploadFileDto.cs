using Apps.Slack.DynamicHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Slack.Models;

public class UploadFileDto
{
    [Display("Channel ID")]
    [DataSource(typeof(ChannelHandler))]
    public string ChannelId { get; set; }
    
    public byte[] File { get; set; }

    public string FileName { get; set; }
}