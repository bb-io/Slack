using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Slack.Webhooks.Payload;

public class BasePayload<T>
{
    [JsonProperty("token")]
    public string Token { get; set; }

    [Display("Team ID")]
    [JsonProperty("team_id")]
    public string TeamId { get; set; }

    [Display("Api app ID")]
    [JsonProperty("api_app_id")]
    public string ApiAppId { get; set; }

    [JsonProperty("event")]
    public T Event { get; set; }
    [JsonProperty("type")]
    public string Type { get; set; }

    [Display("Event ID")]
    [JsonProperty("event_id")]
    public string EventId { get; set; }

    [Display("Event time")]
    [JsonProperty("event_time")]
    public long EventTime { get; set; }

    [Display("Authed users")]
    [JsonProperty("authed_users")]
    public string AuthedUsers { get; set; }
    [JsonProperty("challenge")]
    public string Challenge { get; set; }
}