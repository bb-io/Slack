using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Slack.Models.Responses.Message;

public class PostMessageResponse
{
    [Display("Channel ID")]
    [JsonPropertyName("channel")]
    public string Channel { get; set; }

    [Display("Message timestamp")]
    [JsonPropertyName("ts")]
    public string Timestamp { get; set; }
}