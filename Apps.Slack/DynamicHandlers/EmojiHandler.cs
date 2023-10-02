using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common;
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
