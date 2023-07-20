using Blackbird.Applications.Sdk.Common;

namespace Apps.Slack.Models.Requests
{
    public class DeleteMessageRequest
    {
        [Display("Channel ID")]
        public string Channel { get; set; }

        [Display("Timestamp")]
        public string Ts { get; set; }
    }
}
