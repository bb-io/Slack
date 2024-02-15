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

    [Display("Thread timestamp")]
    public string ThreadTimestamp { get; set; }

    [Display("Channel ID")]
    public string ChannelId { get; set; }

    [Display("Files")]
    public IEnumerable<FileReference> Files { get; set; }

}

public class SlackFileDto
{
    [Display("File name")]
    public string Filename { get; set; }

    [Display("File URL")]
    public string Url { get; set; }
}