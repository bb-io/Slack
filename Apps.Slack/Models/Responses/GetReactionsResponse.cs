using System.Text.Json.Serialization;

namespace Apps.Slack.Models.Responses
{
    public class GetReactionsResponse
    {
        [JsonPropertyName("message")]
        public Message Message { get; set; }
    }

    public class Message
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("user")]
        public string User { get; set; }

        [JsonPropertyName("team")]
        public string Team { get; set; }

        [JsonPropertyName("permalink")]
        public string Permalink { get; set; }

        [JsonPropertyName("reactions")]
        public Reaction[] Reactions { get; set; }
    }

    public class Reaction
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("users")]
        public string[] Users { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }
    }
}
