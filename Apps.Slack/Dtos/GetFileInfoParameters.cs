using Blackbird.Applications.Sdk.Common;

namespace Apps.Slack.Dtos
{
    public class GetFileInfoParameters
    {
        [Display("File ID")]
        public string FileId { get; set; }
    }
}
