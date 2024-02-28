using Apps.Slack.Models.Responses.File;
using Apps.Slack.Models.Responses.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Slack.Webhooks.Output
{
    public class ChannelMessageWithReaction : GetMessageResponse
    {
        public string Reaction { get; set; }
    }
}
