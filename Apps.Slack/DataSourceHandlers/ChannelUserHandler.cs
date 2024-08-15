﻿using Apps.Slack.Api;
using Apps.Slack.Invocables;
using Apps.Slack.Models.Entities;
using Apps.Slack.Models.Requests.User;
using Apps.Slack.Models.Responses.Channel;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.Slack.DataSourceHandlers;

public class ChannelUserHandler(InvocationContext invocationContext)
    : SlackInvocable(invocationContext), IAsyncDataSourceHandler
{
    public async Task<Dictionary<string, string>> GetDataAsync(DataSourceContext context, CancellationToken token)
    {
        var channelsRequest = new SlackRequest("/conversations.list", Method.Get, Creds);
        channelsRequest.AddQueryParameter("exclude_archived", "true");
        var channels = await Client.Paginate<ChannelPaginationResponse, ChannelEntity>(channelsRequest, token);
        
        var userRequest = new SlackRequest("/users.list", Method.Get, Creds);
        var users = await Client.Paginate<UserPaginationResponse, UserDto>(userRequest, token);

        var channelResult = channels.Where(el =>
                context.SearchString is null ||
                BuildReadableName(el).Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
            .ToDictionary(k => k.Id, v => $"[Channel] {v.Name}");
        
        var userResult = users.Where(el =>
                context.SearchString is null ||
                BuildReadableName(el).Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
            .ToDictionary(k => k.Id, v => $"[User] {v.Name}");
        
        return channelResult.Concat(userResult).ToDictionary(k => k.Key, v => v.Value);
    }
    
    private string BuildReadableName(ChannelEntity channel)
    {
        return $"[Channel] {channel.Name}";
    }
    
    private string BuildReadableName(UserDto user)
    {
        return $"[User] {user.Name}";
    }
}