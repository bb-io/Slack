using Blackbird.Applications.Sdk.Common;

namespace Apps.Slack.Models.Requests.Message;

public class PostMessageRequest
{
    public string Text { get; set; }

    [Display("Channel ID")]
    public string Channel { get; set; }

    public string? Thread_ts { get; set; }

    [Display("Username", Description = "Bot's username. If not set, the bot's default username will be used.")]
    public string? Username { get; set; }

    public bool AsUser { get; set; }
}