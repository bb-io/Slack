using Apps.Slack.Api;
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
        var channelHandler = new ChannelHandler(InvocationContext);
        var channels = await channelHandler.GetDataAsync(context, token);
        
        var userHandler = new UserHandler(InvocationContext);
        var users = await userHandler.GetDataAsync(context, token);
        
        return MergeResults(channels, users);
    }
    
    private Dictionary<string, string> MergeResults(Dictionary<string, string> channels, Dictionary<string, string> users)
    {
        var result = new Dictionary<string, string>();
        
        foreach (var channel in channels)
        {
            result.Add(channel.Key, $"[Channel] {channel.Value}");
        }
        
        foreach (var user in users)
        {
            result.Add(user.Key, $"[User] {user.Value}");
        }
        
        return result;
    }
}