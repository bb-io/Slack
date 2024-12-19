using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Slack.Webhooks.Payload;

public class MemberJoinedEvent
{
    [JsonProperty("type")]
    public string Type { get; set; }

    [Display("User ID")]
    [JsonProperty("user")]
    public string User { get; set; }

    [Display("Channel ID")]
    [JsonProperty("channel")]
    public string Channel { get; set; }

    [Display("Channel Type")]
    [JsonProperty("channel_Type")]
    public string ChannelType { get; set; }

    [Display("Team ID")]
    [JsonProperty("team")]
    public string Team { get; set; }

    [Display("Inviter user ID")]
    [JsonProperty("inviter")]
    public string Inviter { get; set; }

}