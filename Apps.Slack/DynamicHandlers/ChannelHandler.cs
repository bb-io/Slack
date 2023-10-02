using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.Slack.DynamicHandlers
{
    public class ChannelHandler : BaseInvocable, IDataSourceHandler 
    {
        public ChannelHandler(InvocationContext invocationContext) : base(invocationContext)
        {
        }

        public Dictionary<string, string> GetData(DataSourceContext context)
        {
            var contextInv = InvocationContext;
            var channels = new Actions(new InvocationContext()).GetChannels(contextInv.AuthenticationCredentialsProviders);
            return channels.Channels.Where(el => el.Name.Contains(context.SearchString)).ToDictionary(k => k.Id, v => v.Name);
        }
    }
}
