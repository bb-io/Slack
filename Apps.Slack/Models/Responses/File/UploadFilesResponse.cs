using Newtonsoft.Json;

namespace Apps.Slack.Models.Responses.File;

public class UploadFilesResponse
{
    [JsonProperty("ok")]
    public bool Ok { get; set; }
    
    [JsonProperty("files")]
    public List<CompleteUploadFileResponse> Files { get; set; } = null!;
}

public class CompleteUploadFileResponse
{
    [JsonProperty("id")]
    public string Id { get; set; } = null!;
    
    [JsonProperty("title")]
    public string Title { get; set; } = null!;
}