﻿using Apps.Slack.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Slack.Models.Requests.Message;

public class PostMessageInThreadParameters
{
    [Display("Channel ID")]
    [DataSource(typeof(ChannelHandler))]
    public string ChannelId { get; set; }
    
    [Display("Channel message timestamp")]
    public string Timestamp { get; set; }
    
    public string Text { get; set; }
}