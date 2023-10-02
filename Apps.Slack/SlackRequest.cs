using Blackbird.Applications.Sdk.Common.Authentication;
using RestSharp;

namespace Apps.Slack
{
    public class SlackRequest : RestRequest
    {
        public SlackRequest(string endpoint, Method method, IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders) : base(endpoint, method)
        {
            var token = authenticationCredentialsProviders.First(p => p.KeyName == "access_token").Value;
            this.AddHeader("Authorization", $"Bearer {token}");
        }
    }
}
