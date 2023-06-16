using Apps.Slack.Models.Responses;
using Blackbird.Applications.Sdk.Common.Authentication.OAuth2;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Apps.Slack.Connections.OAuth2
{
    public class OAuth2TokenService : IOAuth2TokenService
    {
        private static string TokenUrl = "https://slack.com/api/oauth.v2.access";
        public bool IsRefreshToken(Dictionary<string, string> values)
        {
            return false;
        }

        public async Task<Dictionary<string, string>> RefreshToken(Dictionary<string, string> values, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<Dictionary<string, string?>> RequestToken(
            string state,
            string code,
            Dictionary<string, string> values,
            CancellationToken cancellationToken)
        {
            const string grant_type = "authorization_code";

            var bodyParameters = new Dictionary<string, string>
            {
                { "grant_type", grant_type },
                { "client_id", ApplicationConstants.ClientId },
                { "client_secret", ApplicationConstants.ClientSecret },
                { "redirect_uri", ApplicationConstants.RedirectUri },
                { "code", code }
            };
            return await RequestToken(bodyParameters, cancellationToken);
        }

        public Task RevokeToken(Dictionary<string, string> values)
        {
            var client = new SlackClient();
            var request = new RestRequest("/auth.revoke", Method.Get);
            request.AddHeader("Authorization", $"Bearer {values["access_token"]}");
            return client.GetAsync(request);
        }

        private async Task<Dictionary<string, string>> RequestToken(Dictionary<string, string> bodyParameters, CancellationToken cancellationToken)
        {
            using HttpClient httpClient = new HttpClient();
            using var httpContent = new FormUrlEncodedContent(bodyParameters);
            using var response = await httpClient.PostAsync(TokenUrl, httpContent, cancellationToken);
            var responseContent = await response.Content.ReadAsStringAsync();
            var resultDictionary = JsonSerializer.Deserialize<Dictionary<string, object>>(responseContent)?.ToDictionary(r => r.Key, r => r.Value?.ToString())
                ?? throw new InvalidOperationException($"Invalid response content: {responseContent}");
            return resultDictionary;
        }
    }
}
