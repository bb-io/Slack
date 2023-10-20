using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Slack.Models.Responses.Team;

public class Team
{
    [Display("Team ID")]
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("name")] public string Name { get; set; }

    [Display("Team URL")]
    [JsonProperty("url")]
    public string Url { get; set; }
}

public class TeamInfoResponse
{
    [JsonProperty("team")] public Team Team { get; set; }
}