using Apps.Slack.Models.Responses.File;
using Apps.Slack.Models.Responses.Message;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Slack.Webhooks.Output
{
    public class ChannelMessageWithReaction
    {
        public string Reaction { get; set; }

        [Display("Reaction user ID")]
        public string ReactionUserId { get; set; }

        [Display("Message")]
        public GetMessageFilesResponse Message { get; set; }
    }
}
