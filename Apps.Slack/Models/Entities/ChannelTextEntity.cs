using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Slack.Models.Entities;

public class ChannelTextEntity
{
    [JsonProperty("value")]
    public string? Value { get; set; }

    [Display("Creator ID")]
    [JsonProperty("creator")]
    public string? CreatorId { get; set; }

    [Display("Last set timestamp")]
    [JsonProperty("last_set")]
    public long? LastSet { get; set; }
}
