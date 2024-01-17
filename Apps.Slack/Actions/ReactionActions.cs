using Apps.Slack.Api;
using Apps.Slack.Invocables;
using Apps.Slack.Models.Requests.Reaction;
using Apps.Slack.Models.Responses.Reaction;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.Slack.Actions;

[ActionList]
public class ReactionActions : SlackInvocable
{
    public ReactionActions(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    [Action("Add reaction", Description = "Add a reaction to a message")]
    public Task AddReaction([ActionParameter] AddReactionParameters input)
    {
        var request = new SlackRequest("/reactions.add", Method.Post, Creds)
            .AddJsonBody(
                new AddReactionRequest
                {
                    Channel = input.ChannelId,
                    Timestamp = input.Timestamp,
                    Name = input.Reaction
                });

        return Client.ExecuteWithErrorHandling(request);
    }

    [Action("Remove reaction", Description = "Remove a reaction from a message")]
    public Task DeleteReaction([ActionParameter] DeleteReactionParameters input)
    {
        var request = new SlackRequest("/reactions.remove", Method.Post, Creds)
            .AddJsonBody(
                new DeleteReactionRequest
                {
                    Channel = input.ChannelId,
                    Timestamp = input.Timestamp,
                    Name = input.Name
                });

        return Client.ExecuteWithErrorHandling(request);
    }

    [Action("Get reactions", Description = "Get reactions for a message")]
    public async Task<Message> GetReactions([ActionParameter] GetReactionsParameters input)
    {
        var request = new SlackRequest("/reactions.get", Method.Get, Creds)
            .AddParameter("channel", input.ChannelId)
            .AddParameter("timestamp", input.Timestamp);

        var response = await Client.ExecuteWithErrorHandling<GetReactionsResponse>(request);
        return response.Message;
    }
}