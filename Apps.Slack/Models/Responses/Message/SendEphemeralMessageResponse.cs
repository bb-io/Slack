using Apps.Slack.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Newtonsoft.Json;

namespace Apps.Slack.Models.Responses.Message
{
    public class SendEphemeralMessageResponse
    {
        [Display("Message time stamp", Description = "The channel-specific unique identifier for this message, also serves as a confirmation that the message was sent.")]
        [JsonProperty("message_ts")]
        public string MessageTs { get; set; }
    }
}
