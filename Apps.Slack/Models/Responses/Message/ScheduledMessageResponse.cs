using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Slack.Models.Responses.Message;

public class ScheduledMessageResponse
{
    [Display("Channel ID")]
    [JsonProperty("channel")]
    public string ChannelId { get; set; }
    
    [Display("Scheduled message ID")]
    [JsonProperty("scheduled_message_id")]
    public string MessageId { get; set; }
    
    [Display("Posted at")]
    [JsonProperty("post_at")]
    public string PostedAt { get; set; }
}