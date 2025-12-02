using Apps.Slack.Api;
using Apps.Slack.Invocables;
using Apps.Slack.Models.Entities;
using Apps.Slack.Models.Requests.User;
using Apps.Slack.Models.Responses.User;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Exceptions;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.Slack.Actions;

[ActionList]
public class UserActions(InvocationContext invocationContext) : SlackInvocable(invocationContext)
{
    [Action("Search users", Description = "Get all users in a Slack team. Requires scope: users:read")]
    public Task<GetUsersResponse> GetUsers()
    {
        var request = new SlackRequest("/users.list", Method.Get, Creds);
        return Client.ExecuteWithErrorHandling<GetUsersResponse>(request);
    }

    [Action("Get user", Description = "Get information about a user. Requires scope: users:read")]
    public async Task<UserEntity> GetUserInfo([ActionParameter] GetUserInfoParameters input)
    {        
        var request = new SlackRequest("/users.info", Method.Get, Creds)
            .AddParameter("user", input.UserId);

        var response = await Client.ExecuteWithErrorHandling<GetUserInfoResponse>(request);
        return response.User;
    }

    [Action("Find user by email", Description = "Find a user using an email address. Requires scopes: users:read.email, users:read")]
    public async Task<UserEntity> GetUserByEmail([ActionParameter] GetUserByEmailParameters input)
    {
        var request = new SlackRequest("/users.lookupByEmail", Method.Get, Creds)
            .AddParameter("email", input.Email);

        var response = await Client.ExecuteWithErrorHandling<GetUserByEmailResponse>(request);
        return response.User;
    }
}