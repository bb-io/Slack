using Apps.Slack.Api;
using Apps.Slack.Invocables;
using Apps.Slack.Models.Requests.Message;
using Apps.Slack.Models.Responses.File;
using Apps.Slack.Models.Responses.Message;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.Slack.Actions;

[ActionList]
public class MessageActions : SlackInvocable
{
    public MessageActions(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    [Action("Send message", Description = "Send a message to a Slack channel")]
    public Task<PostMessageResponse> PostMessage([ActionParameter] PostMessageParameters input)
    {
        var request = new SlackRequest("/chat.postMessage", Method.Post, Creds)
            .AddJsonBody(new PostMessageRequest
            {
                Channel = input.ChannelId,
                Text = input.Text
            });

        return Client.ExecuteWithErrorHandling<PostMessageResponse>(request);
    }

    [Action("Get message", Description = "Get message content and file URLs by timestamp")]
    public async Task<GetMessageFilesResponse> GetMessageFiles([ActionParameter] GetMessageParameters input)
    {
        var endpoint =
            $"/conversations.history?channel={input.ChannelId}&latest={input.Timestamp}&limit=1&inclusive=true";
        var request = new SlackRequest(endpoint, Method.Get, Creds);

        var response = await Client.ExecuteWithErrorHandling<GetMessageDto>(request);
        var message = response.Messages.First();

        var files = new List<SlackFileDto>();
        if (message.Files != null)
            files = message.Files.Select(f => new SlackFileDto()
            {
                Url = f.PrivateUrl,
                Filename = f.Name
            }).ToList();

        return new()
        {
            MessageText = message.Text,
            FilesUrls = files
        };
    }

    [Action("Send message in thread", Description = "Send a message in the thread")]
    public Task<PostMessageResponse> PostMessageInThread([ActionParameter] PostMessageInThreadParameters input)
    {
        var request = new SlackRequest("/chat.postMessage", Method.Post, Creds)
            .AddJsonBody(new PostMessageInThreadRequest
            {
                Channel = input.ChannelId,
                Text = input.Text,
                Timestamp = input.Timestamp
            });

        return Client.ExecuteWithErrorHandling<PostMessageResponse>(request);
    }

    [Action("Delete message", Description = "Delete a message from Slack a Slack channel")]
    public Task DeleteMessage([ActionParameter] DeleteMessageParameters input)
    {
        var request = new SlackRequest("/chat.delete", Method.Post, Creds)
            .AddJsonBody(new DeleteMessageRequest
            {
                Channel = input.ChannelId,
                Ts = input.Ts
            });

        return Client.ExecuteWithErrorHandling(request);
    }
}