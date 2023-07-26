using Blackbird.Applications.Sdk.Common;

namespace Apps.Slack.Dtos
{
    public class DeleteMessageParameters
    {
        [Display("Channel ID")]
        public string ChannelId { get; set; }

        [Display("Timestamp")]
        public string Ts { get; set; }
    }
}
