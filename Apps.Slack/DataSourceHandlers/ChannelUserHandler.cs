using Apps.Slack.Api;
using Apps.Slack.Invocables;
using Apps.Slack.Models.Entities;
using Apps.Slack.Models.Responses.Channel;
using Apps.Slack.Models.Responses.User;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.Slack.DataSourceHandlers;

public class ChannelUserHandler(InvocationContext invocationContext)
    : SlackInvocable(invocationContext), IAsyncDataSourceItemHandler
{
    public async Task<IEnumerable<DataSourceItem>> GetDataAsync(DataSourceContext context, CancellationToken token)
    {
        var channelsRequest = new SlackRequest("/conversations.list", Method.Get, Creds);
        channelsRequest.AddQueryParameter("exclude_archived", "true");
        var channels = await Client.Paginate<ChannelPaginationResponse, ChannelEntity>(channelsRequest, token);
        
        var userRequest = new SlackRequest("/users.list", Method.Get, Creds);
        var users = await Client.Paginate<UserPaginationResponse, UserEntity>(userRequest, token);

        var channelResult = channels.Where(el =>
                context.SearchString is null ||
                BuildReadableName(el).Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
            .ToDictionary(k => k.Id, BuildReadableName);
        
        var userResult = users.Where(el =>
                context.SearchString is null ||
                BuildReadableName(el).Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
            .ToDictionary(k => k.Id, BuildReadableName);
        
        return channelResult.Concat(userResult).Select(x => new DataSourceItem(x.Key, x.Value));
    }
    
    private string BuildReadableName(ChannelEntity channel)
    {
        return $"[Channel] {channel.Name}";
    }
    
    private string BuildReadableName(UserEntity user)
    {
        var username = user.Profile.DisplayNameNormalized;
        if (string.IsNullOrWhiteSpace(username))
        {
            username = user.Name;
        }
        
        return $"[User] {username}";
    }

}