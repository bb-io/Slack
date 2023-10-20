using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Slack.DataSourceHandlers.EnumDataHandlers;

public class ParseDataSourceHandler : IDataSourceHandler
{
    public Dictionary<string, string> GetData(DataSourceContext context)
    {
        var values = new Dictionary<string, string>()
        {
            ["none"] = "None",
            ["full"] = "Full"
        };

        return values
            .Where(x => context.SearchString is null ||
                        x.Value.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
            .ToDictionary(x => x.Key, x => x.Value);
    }
}