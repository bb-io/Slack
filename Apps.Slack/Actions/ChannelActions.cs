using Apps.Slack.Api;
using Apps.Slack.Constants;
using Apps.Slack.Extensions;
using Apps.Slack.Invocables;
using Apps.Slack.Models.Requests.Channel;
using Apps.Slack.Models.Responses.Channel;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.Slack.Actions;

[ActionList]
public class ChannelActions(InvocationContext invocationContext) : SlackInvocable(invocationContext)
{
    //[Action("Get all channels", Description = "Get all channels in a Slack team")]
    //public Task<GetChannelsResponse> GetChannels()
    //{
    //    var request = new SlackRequest("/conversations.list", Method.Get, Creds);
    //    return Client.ExecuteWithErrorHandling<GetChannelsResponse>(request);
    //}

    [Action("Create channel", Description = "Create a new channel in a Slack team")]
    public Task<ChannelResponse> CreateChannel([ActionParameter] CreateChannelRequest input)
    {
        var request = new SlackRequest("/conversations.create", Method.Post, Creds)
            .WithJsonBody(input, JsonConfig.Settings);

        return Client.ExecuteWithErrorHandling<ChannelResponse>(request);
    }
}