using Blackbird.Applications.Sdk.Common;

namespace Apps.Slack.Models.Responses.File;

public class GetMessageFilesResponse
{
    [Display("Message text")]
    public string? MessageText { get; set; }

    [Display("File urls")]
    public IEnumerable<SlackFileDto> FilesUrls { get; set; }
}

public class SlackFileDto
{
    public string Filename { get; set; }

    public string Url { get; set; }
}