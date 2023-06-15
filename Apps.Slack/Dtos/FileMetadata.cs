using System.Text.Json.Serialization;

namespace Apps.Slack.Dtos
{
    public class FileMetadata
    {
        [JsonPropertyName("next_cursor")]
        public string NextCursor { get; set; }
    }
}
