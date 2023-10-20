using Blackbird.Applications.Sdk.Common.Authentication;
using RestSharp;

namespace Apps.Slack.Api;

public class SlackRequest : RestRequest
{
    public SlackRequest(string endpoint, Method method, IEnumerable<AuthenticationCredentialsProvider> creds) : base(
        endpoint, method)
    {
        var token = creds.First(x => x.KeyName == "access_token").Value;
        this.AddHeader("Authorization", $"Bearer {token}");
    }
}