using Apps.Slack.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Newtonsoft.Json;

namespace Apps.Slack.Models.Requests.Message
{
    public class SendEphemeralMessageRequest
    {
        [Display("User ID", Description = "The ID of the user to show the ephemeral message to")]
        [DataSource(typeof(UserHandler))]
        //[JsonProperty("user_id")]
        public string UserId { get; set; }

        [Display("Channel ID", Description = "The conversation ID for the channel you are sending the message to")]
        [DataSource(typeof(ChannelHandler))]
        //[JsonProperty("channel_id")]
        public string ChannelId { get; set; }

        [Display("Message", Description = "The textual message to send to ephemerally")]
        //[JsonProperty("message")]
        public string Message { get; set; }

        [Display("Thread timestamp", Description = "The ts identifier of an existing message to send this message to as a reply.")]
        //[JsonProperty("thread_ts")]
        public string? ThreadTs { get; set; }

    }
}