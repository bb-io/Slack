using Apps.Slack.Dtos;
using System.Text.Json.Serialization;

namespace Apps.Slack.Models.Responses
{
    public class GetFileInfoResponse
    {
        [JsonPropertyName("file")]
        public FileInfoDto File { get; set; }
        public string Content { get; set; }
        public string[] Comments { get; set; }

        [JsonPropertyName("response_metadata")]
        public FileMetadata ResponseMetadata { get; set; }
    }
}
