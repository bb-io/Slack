using Blackbird.Applications.Sdk.Common.Dictionaries;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Slack.DataSourceHandlers.EnumDataHandlers
{
    public class ReplyTypeHandlerIDataSourceHandler : IStaticDataSourceItemHandler
    {
        public IEnumerable<DataSourceItem> GetData()
        {
            return new List<DataSourceItem>()
            {
                new("only_replies", "Only on replies"),
                new("no_replies", "Only on regular messages"),
                new("both", "Both (default)"),
            };
        }
    }
}
