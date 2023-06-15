using System.Text.Json.Serialization;

namespace Apps.Slack.Dtos
{
    public class ReminderInfoDto
    {
        public string Id { get; set; }
        public string Creator { get; set; }
        public string User { get; set; }
        public string Text { get; set; }
        public string Time { get; set; }
        public bool Recurring { get; set; }

        [JsonPropertyName("complete_ts")]
        public string CompleteTs { get; set; }
    }
}
