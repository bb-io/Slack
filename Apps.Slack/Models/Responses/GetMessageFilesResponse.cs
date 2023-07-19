using Blackbird.Applications.Sdk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Slack.Models.Responses
{
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
}
