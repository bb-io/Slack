using Apps.Slack.DynamicHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Slack.Dtos
{
    public class GetReactionsParameters
    {
        [Display("Channel ID")]
        [DataSource(typeof(ChannelHandler))]
        public string ChannelId { get; set; }
        public string Timestamp { get; set; }
    }
}
