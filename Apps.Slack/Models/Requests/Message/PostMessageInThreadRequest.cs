namespace Apps.Slack.Models.Requests.Message;

public class PostMessageInThreadRequest
{
    public string Text { get; set; }
    public string Channel { get; set; }
    public string Thread_ts { get; set; }
}