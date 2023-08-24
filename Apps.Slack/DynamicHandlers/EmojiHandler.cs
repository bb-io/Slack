using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.Slack.DynamicHandlers
{
    public class EmojiHandler : BaseInvocable, IDataSourceHandler
    {
        public EmojiHandler(InvocationContext invocationContext) : base(invocationContext)
        {
        }

        public Dictionary<string, string> GetData(DataSourceContext context)
        {
            var contextInv = InvocationContext;
            
            return new Dictionary<string, string> {
                {"grinning_face", "😀" }
            };
        }
    }
}
