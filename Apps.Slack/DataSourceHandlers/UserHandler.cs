using Apps.Slack.Api;
using Apps.Slack.Invocables;
using Apps.Slack.Models.Entities;
using Apps.Slack.Models.Requests.User;
using Apps.Slack.Models.Responses.User;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.Slack.DataSourceHandlers;

public class UserHandler(InvocationContext invocationContext)
    : SlackInvocable(invocationContext), IAsyncDataSourceHandler
{
    public async Task<Dictionary<string, string>> GetDataAsync(DataSourceContext context, CancellationToken token)
    {
        var userRequest = new SlackRequest("/users.list", Method.Get, Creds);
        var users = await Client.Paginate<UserPaginationResponse, UserEntity>(userRequest, token);
        
        return users.Where(el =>
                context.SearchString is null ||
                GetReadableName(el).Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
            .ToDictionary(k => k.Id, GetReadableName);
    }

    private string GetReadableName(UserEntity dto)
    {
        var name = dto.Profile.DisplayNameNormalized;
        if (string.IsNullOrEmpty(name))
        {
            name = dto.Name;
        }
        
        return name;
    }
}