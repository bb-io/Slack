﻿using Apps.Slack.Api;
using Apps.Slack.Invocables;
using Apps.Slack.Models.Responses.Team;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.Slack.Actions;

public class TeamActions : SlackInvocable
{
    public TeamActions(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    [Action("Get team", Description = "Get user team info")]
    public Task<TeamInfoResponse> GetTeam()
    {
        var request = new SlackRequest("/team.info", Method.Get, Creds);
        return Client.ExecuteWithErrorHandling<TeamInfoResponse>(request);
    }
}