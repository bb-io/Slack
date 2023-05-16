namespace Apps.Slack.Models
{
    public class DeleteMessageRequest
    {
        public string Channel { get; set; }
        public string Ts { get; set; }
    }
}
