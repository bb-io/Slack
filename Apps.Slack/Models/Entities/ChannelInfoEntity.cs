using Apps.Slack.Models.Converters;
using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Slack.Models.Entities;

public class ChannelInfoEntity : ChannelEntity
{
    [JsonProperty("topic")]
    [JsonConverter(typeof(ChannelTextValueConverter))]
    public string? Topic { get; set; }

    [JsonProperty("purpose")]
    [JsonConverter(typeof(ChannelTextValueConverter))]
    public string? Purpose { get; set; }

    [Display("Creator ID")]
    [JsonProperty("creator")]
    public string? CreatorId { get; set; }

    [Display("Creation timestamp", Description = "Channel creation time in Unix seconds.")]
    [JsonProperty("created")]
    public long? Created { get; set; }

    [Display("Member count")]
    [JsonProperty("num_members")]
    public int? MemberCount { get; set; }

    [Display("Is private")]
    [JsonProperty("is_private")]
    public bool? IsPrivate { get; set; }

    [Display("Is archived")]
    [JsonProperty("is_archived")]
    public bool? IsArchived { get; set; }

    [Display("Is shared")]
    [JsonProperty("is_shared")]
    public bool? IsShared { get; set; }

    [Display("Is member", Description = "Whether the connected bot or user is a member of the channel.")]
    [JsonProperty("is_member")]
    public bool? IsMember { get; set; }
}
