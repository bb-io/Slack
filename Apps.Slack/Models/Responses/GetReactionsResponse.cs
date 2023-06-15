namespace Apps.Slack.Models.Responses
{
    public class GetReactionsResponse
    {
        public Message Message { get; set; }
    }

    public class Message
    {
        public string Text { get; set; }
        public string User { get; set; }
        public string Team { get; set; }
        public string Permalink { get; set; }
        public Reaction[] Reactions { get; set; }
    }

    public class Reaction
    {
        public string Name { get; set; }
        public string[] Users { get; set; }
        public int Count { get; set; }
    }
}
