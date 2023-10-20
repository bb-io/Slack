using Apps.Slack.Models.Entities;
using Newtonsoft.Json;

namespace Apps.Slack.Models.Responses.File;

public class UploadFileResponse
{
    [JsonProperty("file")]
    public FileEntity File { get; set; }
}