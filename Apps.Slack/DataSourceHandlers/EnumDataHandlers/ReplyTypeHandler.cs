using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Slack.DataSourceHandlers.EnumDataHandlers
{
    public class ReplyTypeHandlerIDataSourceHandler : IStaticDataSourceHandler
    {
        public Dictionary<string, string> GetData()
        {
            return new Dictionary<string, string>()
            {
                ["only_replies"] = "Only on replies",
                ["no_replies"] = "Only on regular messages",
                ["both"] = "Both (default)",               
            };
        }
    }
}
