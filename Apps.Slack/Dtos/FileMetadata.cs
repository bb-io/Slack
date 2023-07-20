using Blackbird.Applications.Sdk.Common;
using System.Text.Json.Serialization;

namespace Apps.Slack.Dtos
{
    public class FileMetadata
    {
        [Display("Next cursor")]
        [JsonPropertyName("next_cursor")]
        public string NextCursor { get; set; }
    }
}
