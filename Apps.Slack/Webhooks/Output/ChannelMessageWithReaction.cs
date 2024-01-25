using Apps.Slack.Models.Responses.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Slack.Webhooks.Output
{
    public class ChannelMessageWithReaction : GetMessageFilesResponse
    {
        public string Reaction { get; set; }
    }
}
