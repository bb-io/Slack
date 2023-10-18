using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Slack.Models.Responses.Team;

public class Team
{
    [Display("Team ID")]
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("name")] public string Name { get; set; }

    [Display("Team URL")]
    [JsonPropertyName("url")]
    public string Url { get; set; }
}

public class TeamInfoResponse
{
    [JsonPropertyName("team")] public Team Team { get; set; }
}