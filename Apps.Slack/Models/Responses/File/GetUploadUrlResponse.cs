using Newtonsoft.Json;

namespace Apps.Slack.Models.Responses.File;

public class GetUploadUrlResponse
{
    [JsonProperty("ok")]
    public bool Ok { get; set; }
    
    [JsonProperty("upload_url")]
    public string UploadUrl { get; set; } = null!;

    [JsonProperty("file_id")]
    public string FileId { get; set; } = null!;

    [JsonProperty("error")]
    public string Error { get; set; } = null!;
}