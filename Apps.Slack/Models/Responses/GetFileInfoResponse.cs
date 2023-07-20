using Apps.Slack.Dtos;
using Blackbird.Applications.Sdk.Common;
using System.Text.Json.Serialization;

namespace Apps.Slack.Models.Responses
{
    public class GetFileInfoResponse
    {
        public FileInfoDto File { get; set; }
        public string Content { get; set; }
        public string[] Comments { get; set; }

        [Display("Response metadata")]
        [JsonPropertyName("response_metadata")]
        public FileMetadata ResponseMetadata { get; set; }
    }
}
