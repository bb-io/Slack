namespace Apps.Slack.Models.Requests
{
    public class AddReactionRequest
    {
        public string Channel { get; set; }
        public string Timestamp { get; set; }
        public string Name { get; set; }
    }
}
