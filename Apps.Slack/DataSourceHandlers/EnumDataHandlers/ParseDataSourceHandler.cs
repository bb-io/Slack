using Blackbird.Applications.Sdk.Common.Dictionaries;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Slack.DataSourceHandlers.EnumDataHandlers;

public class ParseDataSourceHandler : IStaticDataSourceHandler
{
    public Dictionary<string, string> GetData()
    {
        return new Dictionary<string, string>()
        {
            ["none"] = "None",
            ["full"] = "Full"
        };
    }
}