using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Slack.Webhooks.Payload;

public class MemberJoinedEvent
{
    [JsonProperty("type")]
    public string Type { get; set; }
    [JsonProperty("user")]
    public string User { get; set; }

    [Display("Channel ID")]
    [JsonProperty("channel")]
    public string Channel { get; set; }
    [Display("Channel Type")]
    [JsonProperty("channel_Type")]
    public string ChannelType { get; set; }
    [JsonProperty("team")]
    public string Team { get; set; }
    [JsonProperty("inviter")]
    public string Inviter { get; set; }

}