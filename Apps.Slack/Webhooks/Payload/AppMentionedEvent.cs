using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Slack.Webhooks.Payload;

public class AppMentionedEvent
{
    [JsonProperty("type")]
    public string Type { get; set; }
    [JsonProperty("user")]
    public string User { get; set; }
    [JsonProperty("text")]
    public string Text { get; set; }

    [Display("Timestamp")]
    [JsonProperty("ts")]
    public string Ts { get; set; }
    [JsonProperty("channel")]

    [Display("Channel ID")]
    public string Channel { get; set; }

    [Display("Event timestamp")]
    [JsonProperty("event_ts")]
    public string EventTs { get; set; }
}