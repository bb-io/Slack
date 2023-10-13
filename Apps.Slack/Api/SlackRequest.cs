using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Utils.Extensions.Sdk;
using RestSharp;

namespace Apps.Slack.Api;

public class SlackRequest : RestRequest
{
    public SlackRequest(string endpoint, Method method, IEnumerable<AuthenticationCredentialsProvider> creds) : base(
        endpoint, method)
    {
        var token = creds.Get("access_token").Value;
        this.AddHeader("Authorization", $"Bearer {token}");
    }
}