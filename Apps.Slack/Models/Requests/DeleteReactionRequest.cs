namespace Apps.Slack.Models.Requests
{
    public class DeleteReactionRequest
    {
        public string Channel { get; set; }
        public string Timestamp { get; set; }
        public string Name { get; set; }
    }
}
