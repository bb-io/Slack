using Apps.Slack.Api;
using Apps.Slack.Constants;
using Apps.Slack.Extensions;
using Apps.Slack.Invocables;
using Apps.Slack.Models.Entities;
using Apps.Slack.Models.Requests.Channel;
using Apps.Slack.Models.Requests.Message;
using Apps.Slack.Models.Requests.User;
using Apps.Slack.Models.Responses.File;
using Apps.Slack.Models.Responses.Message;
using Apps.Slack.Models.Responses.Reaction;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Exceptions;
using Blackbird.Applications.Sdk.Common.Files;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Utils.Extensions.Files;
using Blackbird.Applications.SDK.Extensions.FileManagement.Interfaces;
using Newtonsoft.Json;
using RestSharp;

namespace Apps.Slack.Actions;

[ActionList]
public class MessageActions(InvocationContext invocationContext, IFileManagementClient fileManagementClient)
    : SlackInvocable(invocationContext)
{
    private IFileManagementClient FileManagementClient { get; set; } = fileManagementClient;

    [Action("Send message", Description = "Send a message to a channel or user")]
    public async Task<PostMessageResponse> PostMessage([ActionParameter] PostMessageParameters input)
    {
        string? iconUrl = null;
        string? username = null;
        if (input.SendAsUserId is not null)
        {
            var userActions = new UserActions(invocationContext);
            var user = await userActions.GetUserInfo(new GetUserInfoParameters()
            { UserId = input.SendAsUserId });
            iconUrl = user.Profile.Image72;
            username = string.IsNullOrEmpty(user.Profile.DisplayNameNormalized)
                ? user.Name
                : user.Profile.DisplayNameNormalized;
        }

        var endpoint = "/chat.postMessage";
        if (input.PostAt.HasValue) endpoint = "/chat.scheduleMessage";
        if (input.EphemeralUserId != null) endpoint = "/chat.postEphemeral";

        var postMessageRequest = new SlackRequest(endpoint, Method.Post, Creds)
            .WithJsonBody(new
            {
                channel = input.ChannelId,
                user = input.EphemeralUserId,
                text = input.Text,
                thread_ts = input.Timestamp,
                username = input.Username ?? username,
                icon_url = iconUrl ?? string.Empty,
                post_at = input.PostAt.HasValue ? (long?)new DateTimeOffset(input.PostAt.Value).ToUnixTimeSeconds() : null,
            }, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

        return await Client.ExecuteWithErrorHandling<PostMessageResponse>(postMessageRequest);
    }

    [Action("Send files", Description = "Send files to a channel")]
    public async Task PostMessageWithFiles([ActionParameter] PostFilesParameters input)
    {
        if (input.Files == null || !input.Files.Any())
        {
            throw new PluginMisconfigurationException("Files input is null or empty. Please check you input and try again");
        }

        var uploadedFiles = new List<object>();
        foreach (var attachment in input.Files)
        {
            await using var fileStream = await FileManagementClient.DownloadAsync(attachment);
            var memoryStream = new MemoryStream();
            await fileStream.CopyToAsync(memoryStream);
            memoryStream.Position = 0;

            var length = attachment.Size == 0 ? memoryStream.Length : attachment.Size;
            var getUploadUrlRequest = new SlackRequest("/files.getUploadURLExternal", Method.Get, Creds)
                .AddParameter("filename", attachment.Name)
                .AddParameter("length", length);

            var getUploadUrlResponse =
                await Client.ExecuteWithErrorHandling<GetUploadUrlResponse>(getUploadUrlRequest);
            var uploadUrl = getUploadUrlResponse.UploadUrl;

            var fileAttachment = await memoryStream.GetByteData();
            var uploadFileRequest = new RestRequest(uploadUrl, Method.Post)
                .AddFile("file", fileAttachment, attachment.Name);

            await Client.ExecuteAsync(uploadFileRequest);
            uploadedFiles.Add(new { id = getUploadUrlResponse.FileId, title = attachment.Name });
        }

        var completeUploadBody = new Dictionary<string, object>()
            {
                { "files", uploadedFiles.ToArray() },
                { "channel_id", input.ChannelId },
                { "initial_comment", input.Text ?? string.Empty }
            };

        if (!string.IsNullOrEmpty(input.Timestamp))
        {
            completeUploadBody.Add("thread_ts", input.Timestamp);
        }

        var completeUploadRequest = new SlackRequest("/files.completeUploadExternal", Method.Post, Creds)
            .WithJsonBody(completeUploadBody);

        await Client.ExecuteWithErrorHandling<UploadFilesResponse>(completeUploadRequest);
    }

    [Action("Get message", Description = "Get message metadata, content, reactions and and attachments")]
    public async Task<GetMessageFilesResponse> GetMessageFiles([ActionParameter] ChannelRequest channel,
        [ActionParameter] GetMessageParameters input)
    {
        var endpoint =
            $"/conversations.replies?channel={channel.ChannelId}&ts={input.Timestamp}&limit=1&inclusive=true";
        var request = new SlackRequest(endpoint, Method.Get, Creds);

        var response = await Client.ExecuteWithErrorHandling<GetMessageDto>(request);
        var message = response.Messages.FirstOrDefault(x => x.Ts == input.Timestamp);

        var fileReferences = new List<FileReference>();
        if (message?.Files != null)
        {
            foreach (var f in message.Files)
            {
                //better but needs debugging
                //var fileRequest = new HttpRequestMessage(HttpMethod.Get, f.PrivateUrl);
                //fileRequest.Headers.Add("Authorization", $"Bearer {Creds.Get("access_token").Value}");
                //var reference = new FileReference(fileRequest, f.Name, MimeTypes.GetMimeType(f.Name));
                //fileReferences.Add(reference);

                var fileRequest = new SlackRequest(f.PrivateUrl, Method.Get, Creds);
                var fileResponse = Client.Get(fileRequest);
                using (var stream = new MemoryStream(fileResponse.RawBytes!))
                {
                    var file = FileManagementClient
                        .UploadAsync(stream, fileResponse.ContentType, f.Name).Result;
                    fileReferences.Add(file);
                }
            }
        }

        var reactionsRequest = new SlackRequest("/reactions.get", Method.Get, Creds)
            .AddParameter("channel", channel.ChannelId)
            .AddParameter("timestamp", input.Timestamp);

        var reactionsResponse = await Client.ExecuteWithErrorHandling<GetReactionsResponse>(reactionsRequest);

        return new()
        {
            MessageText = message?.Text,
            ChannelId = channel.ChannelId,
            Timestamp = message?.Ts,
            ThreadTimestamp = message?.Thread_ts,
            User = message?.User,
            Files = fileReferences,
            Reactions = reactionsResponse?.Message?.Reactions ?? new List<ReactionData>(),
        };
    }

    [Action("Update message", Description = "Update a specific message in a Slack channel")]
    public Task<MessageEntity> UpdateMessage([ActionParameter] ChannelRequest channel, [ActionParameter] UpdateMessageParameters input)
    {
        var request = new SlackRequest("/chat.update", Method.Post, Creds)
            .WithJsonBody(new
            {
                Channel = channel.ChannelId,
                Ts = input.Ts,
                text = input.Text

            }, JsonConfig.Settings);

        return Client.ExecuteWithErrorHandling<MessageEntity>(request);
    }

    [Action("Delete message", Description = "Delete a message from Slack a Slack channel")]
    public Task DeleteMessage([ActionParameter] ChannelRequest channel, [ActionParameter] DeleteMessageParameters input)
    {
        var request = new SlackRequest("/chat.delete", Method.Post, Creds)
            .AddJsonBody(new DeleteMessageRequest
            {
                Channel = channel.ChannelId,
                Ts = input.Ts
            });

        return Client.ExecuteWithErrorHandling(request);
    }
}