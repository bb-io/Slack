using System.Text.Json.Serialization;

namespace Apps.Slack.Models.Requests.Message;

public class PostMessageInThreadRequest
{
    public string Text { get; set; }
    
    public string Channel { get; set; }
    
    [JsonPropertyName("thread_ts")]
    public string Timestamp { get; set; }
}