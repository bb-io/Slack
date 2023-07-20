using Blackbird.Applications.Sdk.Common;

namespace Apps.Slack.Dtos
{
    public class DeleteFileParameters
    {
        [Display("File ID")]
        public string FileId { get; set; }
    }
}
