﻿using Apps.Slack.Constants;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Authentication.OAuth2;
using Blackbird.Applications.Sdk.Common.Invocation;
using Microsoft.AspNetCore.WebUtilities;

namespace Apps.Slack.Connections.OAuth2;

public class OAuth2AuthorizationService : BaseInvocable, IOAuth2AuthorizeService
{
    public OAuth2AuthorizationService(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    public string GetAuthorizationUrl(Dictionary<string, string> values)
    {
        string bridgeOauthUrl = $"{InvocationContext.UriInfo.BridgeServiceUrl.ToString().TrimEnd('/')}/oauth";
        var parameters = new Dictionary<string, string>
        {
            { "scope", ApplicationConstants.Scope },
            { "client_id", ApplicationConstants.ClientId },
            { "redirect_uri", $"{InvocationContext.UriInfo.BridgeServiceUrl.ToString().TrimEnd('/')}/AuthorizationCode" },
            { "state", values["state"] },
            { "authorization_url", Urls.OAuth},
            { "actual_redirect_uri", InvocationContext.UriInfo.AuthorizationCodeRedirectUri.ToString() },
        };

        return QueryHelpers.AddQueryString(bridgeOauthUrl, parameters);
    }
}