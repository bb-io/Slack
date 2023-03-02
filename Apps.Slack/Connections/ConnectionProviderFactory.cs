using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Authentication;

namespace Apps.Slack.Connections
{
    public class ConnectionProviderFactory : IConnectionProviderFactory
    {
        public IEnumerable<IConnectionProvider> Create()
        {
            yield return new ConnectionProvider();
        }
    }
}
