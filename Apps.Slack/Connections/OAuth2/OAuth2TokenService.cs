using Blackbird.Applications.Sdk.Common.Authentication.OAuth2;
using RestSharp;
using Apps.Slack.Api;
using Apps.Slack.Constants;
using Newtonsoft.Json;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Invocation;
using Microsoft.Extensions.Logging;

namespace Apps.Slack.Connections.OAuth2;

public class OAuth2TokenService : BaseInvocable, IOAuth2TokenService
{
    private readonly ILogger<OAuth2TokenService> _logger;
    public OAuth2TokenService(InvocationContext invocationContext, ILogger<OAuth2TokenService> logger) : base(invocationContext)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _logger.LogInformation("OAuth2TokenService is initialized.");
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
        _logger.LogInformation("Requesting token with parameters: {Parameters}",
            string.Join(", ", bodyParameters.Select(kv => $"{kv.Key}: {kv.Value}")));

        using var httpContent = new FormUrlEncodedContent(bodyParameters);
        using var response = await httpClient.PostAsync(Urls.Token, httpContent, cancellationToken);
        _logger.LogInformation("Response status: {StatusCode}", response.StatusCode);

        var responseContent = await response.Content.ReadAsStringAsync();
        _logger.LogInformation("Response content: {ResponseContent}", responseContent);

       var tokenResponse = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseContent);
            
        if (tokenResponse == null)
        {
            _logger.LogError("Failed to deserialize response: response is null");
            throw new InvalidOperationException($"Invalid response content: {responseContent}");
        }
            
        _logger.LogInformation("Response keys: {Keys}", string.Join(", ", tokenResponse.Keys));
            
        if (!tokenResponse.ContainsKey("access_token"))
        {
            _logger.LogError("access_token not found in response: {ResponseContent}", responseContent);
            throw new InvalidOperationException($"access_token not found in response: {responseContent}");
        }
            
        return tokenResponse.ToDictionary(r => r.Key, r => r.Value?.ToString() ?? string.Empty);
    }
}