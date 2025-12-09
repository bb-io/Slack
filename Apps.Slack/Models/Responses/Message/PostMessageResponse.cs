using Apps.Slack.Extensions;
using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Slack.Models.Responses.Message;

public class PostMessageResponse
{
    [Display("Channel ID")]
    [JsonProperty("channel")]
    public string Channel { get; set; }

    [Display("Message timestamp", Description = "Available if this was not a scheduled message")]
    [JsonProperty("ts")]
    public string Timestamp { get; set; }
    
    [Display("Message timestamp (Datetime)")]
    public DateTime TimestampDateTime => Timestamp.ToDateTime();

    [Display("Scheduled message ID", Description = "Available if the message was scheduled")]
    [JsonProperty("scheduled_message_id")]
    public string? ScheduledMessageId { get; set; }

    [DefinitionIgnore]
    [JsonProperty("post_at")]
    public string? PostedAt { get; set; }

    [Display("Scheduled at")]
    public DateTime ScheduledAt => PostedAt?.ToDateTime() ?? DateTime.MinValue;
}