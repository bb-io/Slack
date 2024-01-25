using Apps.Slack.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Slack.Webhooks.Payload
{
    public class OptionalEmojiInput
    {
        [DataSource(typeof(EmojiHandler))]
        public string? Reaction { get; set; }
    }
}
