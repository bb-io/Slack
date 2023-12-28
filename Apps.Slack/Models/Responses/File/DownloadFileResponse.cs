using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Files;

namespace Apps.Slack.Models.Responses.File;

public class DownloadFileResponse
{
    [Display("File")]
    public FileReference File { get; set; }
}