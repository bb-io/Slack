using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Connections;
using Blackbird.Applications.Sdk.Common.Exceptions;

namespace Apps.Slack.Connections;

public class ConnectionDefinition :  IConnectionDefinition
{
    public IEnumerable<ConnectionPropertyGroup> ConnectionPropertyGroups => new List<ConnectionPropertyGroup>()
    {
        new ConnectionPropertyGroup
        {
            Name = "OAuth2",
            AuthenticationType = ConnectionAuthenticationType.OAuth2,
            ConnectionProperties = new List<ConnectionProperty>()
            {
            }
        }
    };

    public IEnumerable<AuthenticationCredentialsProvider> CreateAuthorizationCredentialsProviders(
        Dictionary<string, string> values)
    {
        if (!values.TryGetValue("access_token", out var token) || string.IsNullOrWhiteSpace(token))
        {
            throw new PluginMisconfigurationException("Slack connection error: Please reconnect Slack in your connection settings.");
        }

        yield return new AuthenticationCredentialsProvider(
            "access_token",
            values["access_token"]
        );
    }
}