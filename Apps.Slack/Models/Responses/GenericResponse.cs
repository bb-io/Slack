using System.Text.Json.Serialization;

namespace Apps.Slack.Models.Responses;

public class GenericResponse
{
    [JsonPropertyName("error")]
    public string Error { get; set; }
}