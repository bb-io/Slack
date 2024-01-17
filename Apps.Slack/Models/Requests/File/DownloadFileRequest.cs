using Blackbird.Applications.Sdk.Common;

namespace Apps.Slack.Models.Requests.File;

public class DownloadFileRequest
{
    [Display("File URL")]
    public string Url { get; set; }
}