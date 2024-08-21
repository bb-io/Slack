using Apps.Slack.DataSourceHandlers.EnumDataHandlers;
using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Slack.Webhooks.Payload
{
    public class OptionalEmojiInput
    {
        [StaticDataSource(typeof(EmojiHandler))]
        public string? Reaction { get; set; }
    }
}
