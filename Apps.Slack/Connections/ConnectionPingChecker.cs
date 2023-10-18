using Apps.Slack.Api;
using Apps.Slack.Models.Responses.Channel;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Connections;
using RestSharp;

namespace Apps.Slack.Connections;

public class ConnectionPingChecker : IConnectionValidator
{
    public ValueTask<ConnectionValidationResponse> ValidateConnection(IEnumerable<AuthenticationCredentialsProvider> authProviders, CancellationToken cancellationToken)
    {
        var client = new SlackClient();
        var request = new SlackRequest("/conversations.list", Method.Get, authProviders);
        var result = "Success";
        
        try
        {
            client.ExecuteWithErrorHandling<GetChannelsResponse>(request);
            return new ValueTask<ConnectionValidationResponse>(new ConnectionValidationResponse()
            {
                IsValid = true,
                Message = "Success"
            });
        }
        catch (Exception ex)
        {
            return new ValueTask<ConnectionValidationResponse>(new ConnectionValidationResponse()
            {
                IsValid = false,
                Message = ex.Message
            });
        }
    }
}