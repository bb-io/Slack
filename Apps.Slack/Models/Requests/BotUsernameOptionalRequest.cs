using Blackbird.Applications.Sdk.Common;

namespace Apps.Slack.Models.Requests;

public class BotUsernameOptionalRequest
{
    [Display("Username", Description = "Bot's username. If not set, the bot's default username will be used.")]
    public string? Username { get; set; }
}