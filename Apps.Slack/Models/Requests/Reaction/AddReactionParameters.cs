using Apps.Slack.DataSourceHandlers.EnumDataHandlers;
using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Slack.Models.Requests.Reaction;

public class AddReactionParameters
{
    public string Timestamp { get; set; }

    [StaticDataSource(typeof(EmojiHandler))]
    public string Reaction { get; set; }
}