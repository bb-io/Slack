using Apps.Slack.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Slack.Models.Requests.Message
{
    public class PostFilesParameters
    {
        [Display("Channel ID")]
        [DataSource(typeof(ChannelHandler))]
        public string ChannelId { get; set; }

        [Display("Files")]
        public IEnumerable<FileReference> Files { get; set; }

        [Display("Message")]
        public string? Text { get; set; }

        [Display("Thread timestamp", Description = "If you are sending a message as part of a thread, set the timestamp of the primary message.")]
        public string? Timestamp { get; set; }
        
    }
}
