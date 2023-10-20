using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Slack.Webhooks.Payload;

public class MessageReactionEvent
{
    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("user")]
    public string User { get; set; }

    [JsonProperty("reaction")]
    public string Reaction { get; set; }

    [Display("Item user")]
    [JsonProperty("item_user")]
    public string ItemUser { get; set; }

    [Display("Event timestamp")]
    [JsonProperty("event_ts")]
    public string EventTs { get; set; }

    [JsonProperty("item")]
    public MessageItem Item { get; set; }
}

public class MessageItem
{
    [JsonProperty("type")]
    public string Type { get; set; }

    [Display("Channel ID")]
    [JsonProperty("channel")]
    public string Channel { get; set; }

    [Display("Message timestamp")]
    [JsonProperty("ts")]
    public string Ts { get; set; }
}