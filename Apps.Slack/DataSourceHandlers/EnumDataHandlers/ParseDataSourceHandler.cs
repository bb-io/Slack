using Blackbird.Applications.Sdk.Common.Dictionaries;

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