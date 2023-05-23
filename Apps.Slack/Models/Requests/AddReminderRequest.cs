namespace Apps.Slack.Models.Requests
{
    public class AddReminderRequest
    {
        public string Text { get; set; }
        public string Time { get; set; }
        public string User { get; set; }
    }
}
