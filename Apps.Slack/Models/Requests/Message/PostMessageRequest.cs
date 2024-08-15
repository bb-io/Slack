using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Slack.Models.Requests.Message;

public class PostMessageRequest
{
    public string Text { get; set; }

    [Display("Channel ID")]
    public string Channel { get; set; }

    public string? Thread_ts { get; set; }

    public string? Username { get; set; }

    [JsonPropertyName("icon_url")]
    public string IconUrl { get; set; } = string.Empty;
}