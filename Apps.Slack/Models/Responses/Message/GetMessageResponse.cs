﻿using Blackbird.Applications.Sdk.Common;
using Apps.Slack.Extensions;
using Blackbird.Applications.Sdk.Common.Files;

namespace Apps.Slack.Models.Responses.Message;

public class GetMessageResponse
{
    [Display("Message")]
    public string? MessageText { get; set; }

    [Display("User ID")]
    public string User { get; set; }

    [Display("Message timestamp")]
    public string Timestamp { get; set; }
        
    [Display("Message timestamp (Datetime)")]
    public DateTime TimestampDateTime => Timestamp.ToDateTime();

    [Display("Thread timestamp")]
    public string ThreadTimestamp { get; set; }
        
    [Display("Thread timestamp (Datetime)")]
    public DateTime ThreadTimestampDateTime => ThreadTimestamp.ToDateTime();

    [Display("Channel ID")]
    public string ChannelId { get; set; }

    [Display("Is thread reply?")]
    public bool IsThreadReply => ThreadTimestamp != null;

    [Display("Has attachments?")]
    public bool HasAttachments { get; set; }
    
    public IEnumerable<FileReference> Files { get; set; }
}