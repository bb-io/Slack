using Apps.Slack.Api;
using Apps.Slack.Invocables;
using Apps.Slack.Models.Entities;
using Apps.Slack.Models.Responses.Channel;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Apps.Slack.DataSourceHandlers;

public class ChannelHandler(InvocationContext invocationContext)
    : SlackInvocable(invocationContext), IAsyncDataSourceItemHandler
{
    public async Task<IEnumerable<DataSourceItem>> GetDataAsync(DataSourceContext context, CancellationToken cancellationToken)
    {
        var request = new SlackRequest("/conversations.list", Method.Get, Creds);
        //request.AddQueryParameter("types", "public_channel,private_channel");
        request.AddQueryParameter("exclude_archived", "true");
        var channels = await Client.Paginate<ChannelPaginationResponse, ChannelEntity>(request, cancellationToken);

        return channels.Where(el =>
                context.SearchString is null ||
                el.Name.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
            .Select(x => new DataSourceItem(x.Id, $"# {x.Name}"));
    }
}