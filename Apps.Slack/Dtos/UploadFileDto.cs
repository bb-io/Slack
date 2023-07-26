using Blackbird.Applications.Sdk.Common;

namespace Apps.Slack.Models;

public class UploadFileDto
{
    [Display("Channel ID")]
    public string ChannelId { get; set; }
    
    public byte[] File { get; set; }

    public string FileName { get; set; }
}