using Blackbird.Applications.Sdk.Common;
using File = Blackbird.Applications.Sdk.Common.Files.File;

namespace Apps.Slack.Models.Responses
{
    public class DownloadFileResponse
    {
        [Display("File")]
        public File File { get; set; }
    }
}
