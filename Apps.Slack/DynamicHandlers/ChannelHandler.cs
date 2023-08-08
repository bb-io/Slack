using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var channels = new Actions().GetChannels(contextInv.AuthenticationCredentialsProviders);
            return channels.Channels.ToDictionary(k => k.Id, v => v.Name);
        }
    }
}
