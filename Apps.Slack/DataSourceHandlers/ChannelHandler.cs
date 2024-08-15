using Apps.Slack.Api;
using Apps.Slack.Invocables;
using Apps.Slack.Models.Entities;
using Apps.Slack.Models.Responses.Channel;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.Slack.DataSourceHandlers;

public class ChannelHandler(InvocationContext invocationContext)
    : SlackInvocable(invocationContext), IAsyncDataSourceHandler
{
    public async Task<Dictionary<string, string>> GetDataAsync(DataSourceContext context, CancellationToken token)
    {
        var request = new SlackRequest("/conversations.list", Method.Get, Creds);
        //request.AddQueryParameter("types", "public_channel,private_channel");
        request.AddQueryParameter("exclude_archived", "true");
        var channels = await Client.Paginate<ChannelPaginationResponse, ChannelEntity>(request, token);

        return channels.Where(el =>
                context.SearchString is null ||
                el.Name.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
            .ToDictionary(k => k.Id, v => $"# {v.Name}");
    }
}