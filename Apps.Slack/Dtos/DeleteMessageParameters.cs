using Apps.Slack.DynamicHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Slack.Dtos
{
    public class DeleteMessageParameters
    {
        [Display("Channel ID")]
        [DataSource(typeof(ChannelHandler))]
        public string ChannelId { get; set; }

        [Display("Timestamp")]
        public string Ts { get; set; }
    }
}
