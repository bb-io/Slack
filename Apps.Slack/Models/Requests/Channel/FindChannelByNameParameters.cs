using Blackbird.Applications.Sdk.Common;

namespace Apps.Slack.Models.Requests.Channel;

public class FindChannelByNameParameters
{
    [Display("Name", Description = "Channel name, with or without the # symbol.")]
    public string Name { get; set; } = string.Empty;
}
