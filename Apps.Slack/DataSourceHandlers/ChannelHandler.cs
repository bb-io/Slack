using Apps.Slack.Api;
using Apps.Slack.Invocables;
using Apps.Slack.Models.Responses.Channel;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.Slack.DataSourceHandlers;

public class ChannelHandler : SlackInvocable, IAsyncDataSourceHandler
{
    public ChannelHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    public async Task<Dictionary<string, string>> GetDataAsync(DataSourceContext context, CancellationToken token)
    {
        var request = new SlackRequest("/conversations.list", Method.Get, Creds);
        var channels = await Client.ExecuteWithErrorHandling<GetChannelsResponse>(request);

        return channels.Channels.Where(el =>
                context.SearchString is null ||
                el.Name.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
            .ToDictionary(k => k.Id, v => v.Name);
    }
}