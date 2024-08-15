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
    public string? Text { get; set; }
    
    public IEnumerable<FileReference>? Attachments { get; set; }

    [Display("Thread timestamp", Description = "If you are sending a message as part of a thread, set the timestamp of the primary message.")]
    public string? Timestamp { get; set; }

    [Display("As user", Description = "(Legacy) Pass true to post the message as the authed user instead of as a bot. Defaults to false.")]
    public bool? AsUser { get; set; }
}