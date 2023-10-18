using Apps.Slack.Api;
using Apps.Slack.Invocables;
using Apps.Slack.Models.Entities;
using Apps.Slack.Models.Requests.User;
using Apps.Slack.Models.Responses.User;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.Slack.Actions;

[ActionList]
public class UserActions : SlackInvocable
{
    public UserActions(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    [Action("Get all users", Description = "Get all users in a Slack team")]
    public Task<GetUsersResponse> GetUsers()
    {
        var request = new SlackRequest("/users.list", Method.Get, Creds);
        return Client.ExecuteWithErrorHandling<GetUsersResponse>(request);
    }

    [Action("Get user information", Description = "Get information about a user")]
    public async Task<UserEntity> GetUserInfo([ActionParameter] GetUserInfoParameters input)
    {
        var request = new SlackRequest("/users.info", Method.Get, Creds)
            .AddParameter("user", input.UserId);

        var response = await Client.ExecuteWithErrorHandling<GetUserInfoResponse>(request);
        return response.User;
    }

    [Action("Get user by email", Description = "Find a user with an email address")]
    public async Task<UserEntity> GetUserByEmail([ActionParameter] GetUserByEmailParameters input)
    {
        var request = new SlackRequest("/users.lookupByEmail", Method.Get, Creds)
            .AddParameter("email", input.Email);

        var response = await Client.ExecuteWithErrorHandling<GetUserByEmailResponse>(request);
        return response.User;
    }

    [Action("Get user profile", Description = "Retrieve a user's profile information, including their custom status")]
    public async Task<UserProfileEntity> GetUserProfile([ActionParameter] GetUserProfileParameters input)
    {
        var request = new SlackRequest("/users.profile.get", Method.Get, Creds)
            .AddParameter("user", input.UserId);

        var response = await Client.ExecuteWithErrorHandling<GetUserProfileResponse>(request);
        return response.Profile;
    }
}