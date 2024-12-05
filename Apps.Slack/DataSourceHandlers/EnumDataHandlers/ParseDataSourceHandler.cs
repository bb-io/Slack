using Blackbird.Applications.Sdk.Common.Dictionaries;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Slack.DataSourceHandlers.EnumDataHandlers;

public class ParseDataSourceHandler : IStaticDataSourceItemHandler
{
    public IEnumerable<DataSourceItem> GetData()
    {
        return new List<DataSourceItem>()
        {
            new ("none", "None"),
            new ("full", "Full"),
        };
    }
}