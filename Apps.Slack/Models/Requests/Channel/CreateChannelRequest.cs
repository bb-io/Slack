using Blackbird.Applications.Sdk.Common;

namespace Apps.Slack.Models.Requests.Channel;

public class CreateChannelRequest
{
    public string Name { get; set; }
    
    [Display("Is private")]
    public bool? IsPrivate { get; set; }
    
    [Display("Team ID")]
    public string? TeamId { get; set; }
}