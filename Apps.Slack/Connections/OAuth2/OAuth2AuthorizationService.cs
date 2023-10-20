using Apps.Slack.Constants;
using Apps.Slack.Extensions;
using Blackbird.Applications.Sdk.Common.Authentication.OAuth2;

namespace Apps.Slack.Connections.OAuth2;

public class OAuth2AuthorizationService : IOAuth2AuthorizeService
{
    public string GetAuthorizationUrl(Dictionary<string, string> values)
    {
        var parameters = new Dictionary<string, string>
        {
            { "scope", ApplicationConstants.Scope },
            { "client_id", ApplicationConstants.ClientId },
            { "redirect_uri", ApplicationConstants.RedirectUri },
            { "state", values["state"] },
        };

        return Urls.OAuth.WithQuery(parameters);
    }
}