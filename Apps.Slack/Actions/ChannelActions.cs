using Apps.Slack.Api;
using Apps.Slack.Invocables;
using Apps.Slack.Models.Entities;
using Apps.Slack.Models.Requests.Channel;
using Apps.Slack.Models.Responses.Channel;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Exceptions;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.Slack.Actions;

[ActionList]
public class ChannelActions(InvocationContext invocationContext) : SlackInvocable(invocationContext)
{
    [Action("Find channel by name", Description = "Find an accessible public or private channel by its exact name, with or without #. Requires scopes: channels:read, groups:read")]
    public async Task<ChannelInfoEntity> FindChannelByName([ActionParameter] FindChannelByNameParameters input)
    {
        var name = input.Name?.Trim();
        if (name?.StartsWith('#') == true)
            name = name[1..].Trim();

        if (string.IsNullOrWhiteSpace(name))
            throw new PluginMisconfigurationException("Channel name must not be empty. Enter a name with or without #.");

        string? cursor = null;
        do
        {
            var request = new SlackRequest("/conversations.list", Method.Get, Creds)
                .AddQueryParameter("types", "public_channel,private_channel")
                .AddQueryParameter("exclude_archived", "true")
                .AddQueryParameter("limit", 999);

            if (cursor is not null)
                request.AddQueryParameter("cursor", cursor);

            var response = await Client.ExecuteWithErrorHandling<ChannelInfoPaginationResponse>(request);
            var channel = response.Items.FirstOrDefault(x =>
                string.Equals(x.Name, name, StringComparison.OrdinalIgnoreCase));

            if (channel is not null)
                return channel;

            cursor = response.ResponseMetadata?.NextCursor;
        } while (!string.IsNullOrWhiteSpace(cursor));

        throw new PluginApplicationException($"No accessible channel named '{name}' was found. Check the name and the Slack connection's channel access.");
    }
}
