using Blackbird.Applications.Sdk.Common;

namespace Apps.Slack.Models.Requests.File;

public class GetFileInfoParameters
{
    [Display("File ID")]
    public string FileId { get; set; }
}