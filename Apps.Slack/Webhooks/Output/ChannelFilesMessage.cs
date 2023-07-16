using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Slack.Webhooks.Output
{
    public class ChannelFilesMessage
    {
        public string? Message { get; set; }
        public string Channel { get; set; }
        public string User { get; set; }

        public List<OutputMessageFile> Files { get; set; }
        public string Timestamp { get; set; }
    }

    public class OutputMessageFile
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public byte[] File { get; set; }

        public string FileType { get; set; }
    }
}
