using Blackbird.Applications.Sdk.Common.Authentication.OAuth2;
using Microsoft.AspNetCore.WebUtilities;

namespace Apps.Slack.Connections.OAuth2
{
    public class OAuth2AuthorizationSerivce : IOAuth2AuthorizeService
    {
        public string GetAuthorizationUrl(Dictionary<string, string> values)
        {
            string oauthUrl = "https://slack.com/oauth/v2/authorize";
            var parameters = new Dictionary<string, string>
            {
                { "scope", ApplicationConstants.Scope},
                { "client_id", ApplicationConstants.ClientId },
                { "redirect_uri", ApplicationConstants.RedirectUri},
                { "state", values["state"] },
            };
            return QueryHelpers.AddQueryString(oauthUrl, parameters);
        }
    }
}
