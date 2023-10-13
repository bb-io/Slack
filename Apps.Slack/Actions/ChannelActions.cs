using Apps.Slack.Api;
using Apps.Slack.Invocables;
using Apps.Slack.Models.Responses.Channel;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.Slack.Actions;

public class ChannelActions : SlackInvocable
{
    public ChannelActions(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    [Action("Get all channels", Description = "Get all channels in a Slack team")]
    public Task<GetChannelsResponse> GetChannels()
    {
        var request = new SlackRequest("/conversations.list", Method.Get, Creds);
        return Client.ExecuteWithErrorHandling<GetChannelsResponse>(request);
    }
}