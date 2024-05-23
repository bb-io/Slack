using Apps.Slack.Extensions;
using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Slack.Models.Responses.Message;

public class PostMessageResponse
{
    [Display("Channel ID")]
    [JsonProperty("channel")]
    public string Channel { get; set; }

    [Display("Message timestamp")]
    [JsonProperty("ts")]
    public string Timestamp { get; set; }
    
    [Display("Message timestamp (Datetime)")]
    public DateTime TimestampDateTime => Timestamp.ToDateTime();
}