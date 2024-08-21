using Apps.Slack.Api;
using Apps.Slack.Extensions;
using Apps.Slack.Invocables;
using Apps.Slack.Models.Requests.Channel;
using Apps.Slack.Models.Requests.Reaction;
using Apps.Slack.Models.Responses.Reaction;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.Slack.Actions;

[ActionList]
public class ReactionActions(InvocationContext invocationContext) : SlackInvocable(invocationContext)
{
    [Action("Add reaction", Description = "Add a reaction to a message")]
    public Task AddReaction([ActionParameter] ChannelRequest channel, [ActionParameter] AddReactionParameters input)
    {
        var channelId = (channel.ChannelId, channel.ManualChannelId).GetChannelId();

        var request = new SlackRequest("/reactions.add", Method.Post, Creds)
            .AddJsonBody(
                new AddReactionRequest
                {
                    Channel = channelId,
                    Timestamp = input.Timestamp,
                    Name = input.Reaction
                });

        return Client.ExecuteWithErrorHandling(request);
    }

    [Action("Remove reaction",
        Description = "Remove a reaction from a message. Note: The Slack bot can only remove reactions it has added.")]
    public Task DeleteReaction([ActionParameter] ChannelRequest channel,
        [ActionParameter] DeleteReactionParameters input)
    {
        var channelId = (channel.ChannelId, channel.ManualChannelId).GetChannelId();

        var request = new SlackRequest("/reactions.remove", Method.Post, Creds)
            .AddJsonBody(
                new DeleteReactionRequest
                {
                    Channel = channelId,
                    Timestamp = input.Timestamp,
                    Name = input.Reaction
                });

        return Client.ExecuteWithErrorHandling(request);
    }

    [Action("Get reactions", Description = "Get reactions for a message")]
    public async Task<Message> GetReactions([ActionParameter] ChannelRequest channel,
        [ActionParameter] GetReactionsParameters input)
    {
        var channelId = (channel.ChannelId, channel.ManualChannelId).GetChannelId();

        var request = new SlackRequest("/reactions.get", Method.Get, Creds)
            .AddParameter("channel", channelId)
            .AddParameter("timestamp", input.Timestamp);

        var response = await Client.ExecuteWithErrorHandling<GetReactionsResponse>(request);
        return response.Message;
    }
}