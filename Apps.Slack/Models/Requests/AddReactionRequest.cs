using Blackbird.Applications.Sdk.Common;

namespace Apps.Slack.Models.Requests
{
    public class AddReactionRequest
    {
        [Display("Channel ID")]
        public string Channel { get; set; }
        public string Timestamp { get; set; }
        public string Name { get; set; }
    }
}
