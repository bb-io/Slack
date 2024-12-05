using Apps.Slack.Api;
using Apps.Slack.Invocables;
using Apps.Slack.Models.Entities;
using Apps.Slack.Models.Responses.User;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.Slack.DataSourceHandlers;

public class UserHandler(InvocationContext invocationContext)
    : SlackInvocable(invocationContext), IAsyncDataSourceItemHandler
{
    public async Task<IEnumerable<DataSourceItem>> GetDataAsync(DataSourceContext context, CancellationToken token)
    {
        var userRequest = new SlackRequest("/users.list", Method.Get, Creds);
        var users = await Client.Paginate<UserPaginationResponse, UserEntity>(userRequest, token);
        
        return users.Where(el =>
                context.SearchString is null ||
                GetReadableName(el).Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
            .Select(x => new DataSourceItem(x.Id, GetReadableName(x)));
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