using Apps.Slack.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Slack.Models.Requests;

public class SendMessageOptionalParameters
{
    [Display("Bot's username", Description = "Bot's username. If not set, the bot's default username will be used. If you will send a message only with attachments, username will be ignored.")]
    public string? Username { get; set; }

    [Display("Send as user", Description = "Send a message as a user. If not set, the message will be sent as a bot."), DataSource(typeof(UserHandler))]
    public string? UserId { get; set; }
}