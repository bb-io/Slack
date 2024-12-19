using Apps.Slack.DataSourceHandlers.EnumDataHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Slack.Models.Requests.Message;

public class UpdateMessageParameters : DeleteMessageParameters
{
    [Display("Message text")]
    public string? Text { get; set; }
    
    [Display("Reply broadcast")]
    public bool? ReplyBroadcast { get; set; }
    
    [Display("Link names")]
    public bool? LinkNames { get; set; }
    
    //[Display("File IDs")]
    //public IEnumerable<string>? FileIds { get; set; }
    
    [StaticDataSource(typeof(ParseDataSourceHandler))]
    public string? Parse { get; set; }
}