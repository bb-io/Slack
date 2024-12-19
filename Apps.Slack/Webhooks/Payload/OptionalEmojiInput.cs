using Apps.Slack.DataSourceHandlers.EnumDataHandlers;
using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Slack.Webhooks.Payload
{
    public class OptionalEmojiInput
    {
        [StaticDataSource(typeof(EmojiHandler))]
        public IEnumerable<string>? Reactions { get; set; }
    }
}
