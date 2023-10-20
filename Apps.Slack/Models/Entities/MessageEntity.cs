using Blackbird.Applications.Sdk.Common;

namespace Apps.Slack.Models.Entities;

public class MessageEntity
{
    [Display("Channel ID")]
    public string Channel { get; set; }
    
    public string Text { get; set; }
    
    [Display("Timestamp")]
    public string Ts { get; set; }
}