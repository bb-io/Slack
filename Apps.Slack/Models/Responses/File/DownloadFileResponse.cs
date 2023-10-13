using Blackbird.Applications.Sdk.Common;

namespace Apps.Slack.Models.Responses.File;

public class DownloadFileResponse
{
    [Display("File")]
    public Blackbird.Applications.Sdk.Common.Files.File File { get; set; }
}