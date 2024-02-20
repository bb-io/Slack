using Blackbird.Applications.Sdk.Common.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Slack.DataSourceHandlers.EnumDataHandlers
{
    public class ReplyTypeHandlerIDataSourceHandler
    {
        public Dictionary<string, string> GetData(DataSourceContext context)
        {
            var values = new Dictionary<string, string>()
            {
                ["only_replies"] = "Only on replies",
                ["no_replies"] = "Only on regular messages",
                ["both"] = "Both (default)",               
            };

            return values
                .Where(x => context.SearchString is null ||
                            x.Value.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
                .ToDictionary(x => x.Key, x => x.Value);
        }
    }
}
