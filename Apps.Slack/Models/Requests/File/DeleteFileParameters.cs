using Blackbird.Applications.Sdk.Common;

namespace Apps.Slack.Models.Requests.File;

public class DeleteFileParameters
{
    [Display("File ID")]
    public string FileId { get; set; }
}