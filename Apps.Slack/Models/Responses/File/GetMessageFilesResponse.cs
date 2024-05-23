using Apps.Slack.Extensions;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Files;

namespace Apps.Slack.Models.Responses.File;

public class GetMessageFilesResponse
{
    [Display("Message")]
    public string? MessageText { get; set; }

    [Display("User ID")]
    public string User { get; set; }

    [Display("Message timestamp")]
    public string Timestamp { get; set; }
    
    [Display("Message timestamp (Datetime)")]
    public DateTime TimestampDateTime => Timestamp.ToDateTime();
    
    [Display("Thread timestamp")]
    public string ThreadTimestamp { get; set; }
    
    [Display("Thread timestamp (Datetime)")]
    public DateTime ThreadTimestampDateTime => Timestamp.ToDateTime();
    
    [Display("Channel ID")]
    public string ChannelId { get; set; }

    [Display("Files")]
    public IEnumerable<FileReference> Files { get; set; }

}