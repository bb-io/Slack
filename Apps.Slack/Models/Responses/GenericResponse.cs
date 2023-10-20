using Newtonsoft.Json;

namespace Apps.Slack.Models.Responses;

public class GenericResponse
{
    [JsonProperty("error")]
    public string Error { get; set; }
}