using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Slack.Webhooks.Payload;

public class ChannelMessageEvent
{
    [JsonProperty("type")]
    public string Type { get; set; }
        
    [JsonProperty("user")]
    public string User { get; set; }
        
    [JsonProperty("text")]
    public string Text { get; set; }
        
    [JsonProperty("ts")]
    [Display("Timestamp")]
    public string Ts { get; set; }
        
    [JsonProperty("channel")]
    [Display("Channel ID")]
    public string Channel { get; set; }

    [Display("Event timestamp")]
    [JsonProperty("event_ts")]
    public string EventTs { get; set; }
        
    [JsonProperty("thread_ts")]
    [Display("Thread timestamp")]
    public string? ThreadTs { get; set; }
}