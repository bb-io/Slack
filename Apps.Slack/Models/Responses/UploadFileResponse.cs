using Apps.Slack.Dtos;
using System.Text.Json.Serialization;

namespace Apps.Slack.Models.Responses
{
    public class UploadFileResponse
    {
        [JsonPropertyName("file")]
        public FileInfoDto File { get; set; }
    }
}
