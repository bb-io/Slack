using Newtonsoft.Json;

namespace Apps.Slack.Models.Responses.Reaction;

public class GetReactionsResponse
{
    [JsonProperty("message")]
    public Message Message { get; set; }
}

public class Message
{
    [JsonProperty("text")]
    public string Text { get; set; }

    [JsonProperty("user")]
    public string User { get; set; }

    [JsonProperty("team")]
    public string Team { get; set; }

    [JsonProperty("permalink")]
    public string Permalink { get; set; }

    [JsonProperty("reactions")]
    public IEnumerable<ReactionData> Reactions { get; set; }
}

public class ReactionData
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("users")]
    public IEnumerable<string> Users { get; set; }

    [JsonProperty("count")]
    public int Count { get; set; }
}