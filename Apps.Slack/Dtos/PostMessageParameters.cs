using Blackbird.Applications.Sdk.Common;

namespace Apps.Slack
{
    public class PostMessageParameters
    {
        [Display("Channel ID")]
        public string ChannelId { get; set; }
        public string Text { get; set; }
    }
}
