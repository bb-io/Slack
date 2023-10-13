using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Slack.Models.Entities;

public class ChannelEntity
{
    [Display("Channel ID")]
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }
}