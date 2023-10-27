using Blackbird.Applications.Sdk.Common.Authentication.OAuth2;
using RestSharp;
using Apps.Slack.Api;
using Apps.Slack.Constants;
using Newtonsoft.Json;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.Slack.Connections.OAuth2;

public class OAuth2TokenService : BaseInvocable, IOAuth2TokenService
{
    public OAuth2TokenService(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    public bool IsRefreshToken(Dictionary<string, string> values)
    {
        return false;
    }

    public Task<Dictionary<string, string>> RefreshToken(Dictionary<string, string> values,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Dictionary<string, string>> RequestToken(
        string state,
        string code,
        Dictionary<string, string> values,
        CancellationToken cancellationToken)
    {
        const string grantType = "authorization_code";

        var bodyParameters = new Dictionary<string, string>
        {
            { "grant_type", grantType },
            { "client_id", ApplicationConstants.ClientId },
            { "client_secret", ApplicationConstants.ClientSecret },
            { "redirect_uri", $"{InvocationContext.UriInfo.BridgeServiceUrl.ToString().TrimEnd('/')}/AuthorizationCode" },
            { "code", code }
        };
        
        return RequestToken(bodyParameters, cancellationToken);
    }

    public Task RevokeToken(Dictionary<string, string> values)
    {
        var client = new SlackClient();
        var request = new RestRequest("/auth.revoke");
        request.AddHeader("Authorization", $"Bearer {values["access_token"]}");
        return client.GetAsync(request);
    }

    private async Task<Dictionary<string, string>> RequestToken(Dictionary<string, string> bodyParameters,
        CancellationToken cancellationToken)
    {
        using var httpClient = new HttpClient();

        using var httpContent = new FormUrlEncodedContent(bodyParameters);
        using var response = await httpClient.PostAsync(Urls.Token, httpContent, cancellationToken);

        var responseContent = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<Dictionary<string, object>>(responseContent)
                   ?.ToDictionary(r => r.Key, r => r.Value?.ToString() ?? string.Empty)
               ?? throw new InvalidOperationException($"Invalid response content: {responseContent}");
    }
}