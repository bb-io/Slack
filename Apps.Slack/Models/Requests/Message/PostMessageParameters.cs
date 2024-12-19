using Apps.Slack.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Files;

namespace Apps.Slack.Models.Requests.Message;

public class PostMessageParameters
{
    [Display("Channel or user ID")]
    [DataSource(typeof(ChannelUserHandler))]
    public string ChannelId { get; set; }
    
    [Display("Message")]
    public string Text { get; set; }

    [Display("Thread timestamp", Description = "If you are sending a message as part of a thread, set the timestamp of the primary message.")]
    public string? Timestamp { get; set; }

    [Display("Schedule at", Description = "If used, creates a scheduled message")]
    public DateTime? PostAt { get; set; }

    [Display("Ephemeral user ID", Description = "If set, the message will only be visible to this user.")]
    [DataSource(typeof(UserHandler))]
    public string? EphemeralUserId { get; set; }

    [Display("Bot's username", Description = "Bot's username. If not set, the bot's default username will be used. If you will send a message only with attachments, username will be ignored.")]
    public string? Username { get; set; }

    [Display("Send as user", Description = "Send a message as a user. If not set, the message will be sent as a bot."), DataSource(typeof(UserHandler))]
    public string? SendAsUserId { get; set; }
}