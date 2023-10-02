namespace Apps.Slack.Webhooks.Output
{
    public class ChannelMessage
    {
        public string Message { get; set; }
        public string Channel { get; set; }
        public string User { get; set; }
        public string Timestamp { get; set; }
    }
}
