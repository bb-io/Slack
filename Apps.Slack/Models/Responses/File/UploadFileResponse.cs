using System.Text.Json.Serialization;
using Apps.Slack.Models.Entities;

namespace Apps.Slack.Models.Responses.File;

public class UploadFileResponse
{
    [JsonPropertyName("file")]
    public FileEntity File { get; set; }
}