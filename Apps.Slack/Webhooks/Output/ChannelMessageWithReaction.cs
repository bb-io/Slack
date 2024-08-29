using Apps.Slack.Models.Responses.Message;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Slack.Webhooks.Output
{
    public class ChannelMessageWithReaction : GetMessageResponse
    {
        public string Reaction { get; set; }

        [Display("Event time")]
        public DateTime EventTimestamp { get; set; }
    }
}
