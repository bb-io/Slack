using Apps.Slack.Dtos;

namespace Apps.Slack.Models.Responses
{
    public class GetRemindersResponse
    {
        public ReminderInfoDto[] Reminders { get; set; }
    }
}
