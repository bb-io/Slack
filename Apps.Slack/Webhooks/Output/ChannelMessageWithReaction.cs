using Apps.Slack.Models.Responses.Message;

namespace Apps.Slack.Webhooks.Output
{
    public class ChannelMessageWithReaction : GetMessageResponse
    {
        public string Reaction { get; set; }
    }
}
