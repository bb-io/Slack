using Blackbird.Applications.Sdk.Common;

namespace Apps.Slack.Dtos
{
    public class AddReactionParameters
    {
        [Display("Channel ID")]
        public string ChannelId { get; set; }
        public string Timestamp { get; set; }
        public string Name { get; set; }
    }
}
