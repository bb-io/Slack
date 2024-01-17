using Blackbird.Applications.Sdk.Common;

namespace Apps.Slack.Models.Responses.File;

public class GetMessageFilesResponse
{
    [Display("Message")]
    public string? MessageText { get; set; }

    [Display("User ID")]
    public string User { get; set; }

    [Display("Timestamp")]
    public string Timestamp { get; set; }

    [Display("Channel ID")]
    public string ChannelId { get; set; }

    [Display("File URLs")]
    public IEnumerable<SlackFileDto> FilesUrls { get; set; }
}

public class SlackFileDto
{
    [Display("File name")]
    public string Filename { get; set; }

    [Display("File URL")]
    public string Url { get; set; }
}