using Apps.Slack.Api;
using Apps.Slack.Constants;
using Apps.Slack.Extensions;
using Apps.Slack.Invocables;
using Apps.Slack.Models.Entities;
using Apps.Slack.Models.Requests.Message;
using Apps.Slack.Models.Responses.File;
using Apps.Slack.Models.Responses.Message;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Files;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Utils.Extensions.Files;
using Blackbird.Applications.SDK.Extensions.FileManagement.Interfaces;
using RestSharp;
using System.IO;
using System.Net.Mail;
using System.Net.Mime;

namespace Apps.Slack.Actions;

[ActionList]
public class MessageActions : SlackInvocable
{
    private IFileManagementClient FileManagementClient { get; set; }
    public MessageActions(InvocationContext invocationContext, IFileManagementClient fileManagementClient) : base(invocationContext)
    {
        FileManagementClient = fileManagementClient;
    }

    [Action("Send message", Description = "Send a message to a Slack channel")]
    public async Task<PostMessageResponse> PostMessage([ActionParameter] PostMessageParameters input)
    {
        if (input.Text == null && input.Attachment == null)
            throw new Exception("Please provide either a message text, attachments, or both.");

        var attachmentsSuffix = string.Empty;
        if (input.Attachment != null)
        {
            using var fileStream = await FileManagementClient.DownloadAsync(input.Attachment);
            var fileAttachment = await fileStream.GetByteData();

            var uploadFileRequest = new SlackRequest("/files.upload", Method.Post, Creds)
                .AddFile("file", fileAttachment, input.Attachment.Name)
                .AddParameter("filename", input.Attachment.Name);

            if (input.Text == null)
            {
                uploadFileRequest.AddParameter("channels", input.ChannelId);
                if (input.Timestamp != null)
                    uploadFileRequest.AddParameter("thread_ts", input.Timestamp);
            };

            var uploadFileResponse = Client.ExecuteWithErrorHandling<UploadFileResponse>(uploadFileRequest).Result;

            attachmentsSuffix += $"<{uploadFileResponse.File.Permalink}| >";

            if (input.Text == null)
                return new PostMessageResponse { Timestamp = uploadFileResponse.File.Timestamp.ToString(), Channel = input.ChannelId };
        }       

        var postMessageRequest = new SlackRequest("/chat.postMessage", Method.Post, Creds)
            .AddJsonBody(new PostMessageRequest
            {
                Channel = input.ChannelId,
                Text = input.Text + attachmentsSuffix,
                Thread_ts = input.Timestamp
            });

        return await Client.ExecuteWithErrorHandling<PostMessageResponse>(postMessageRequest);
    }

    [Action("Send scheduled message", Description = "Send a scheduled message to a Slack channel")]
    public Task<ScheduledMessageResponse> SendScheduledMessage([ActionParameter] PostScheduledMessageParameters input)
    {
        var request = new SlackRequest("/chat.scheduleMessage", Method.Post, Creds)
            .AddParameter("channel", input.ChannelId)
            .AddParameter("text", input.Text)
            .AddParameter("post_at", new DateTimeOffset(input.PostAt).ToUnixTimeSeconds());

        return Client.ExecuteWithErrorHandling<ScheduledMessageResponse>(request);
    }

    [Action("Get message", Description = "Get message content and file URLs by timestamp")]
    public async Task<GetMessageFilesResponse> GetMessageFiles([ActionParameter] GetMessageParameters input)
    {
        var endpoint =
            $"/conversations.replies?channel={input.ChannelId}&ts={input.Timestamp}&limit=1&inclusive=true";
        var request = new SlackRequest(endpoint, Method.Get, Creds);

        var response = await Client.ExecuteWithErrorHandling<GetMessageDto>(request);
        var message = response.Messages.Where(x => x.Ts == input.Timestamp).FirstOrDefault();

        var files = new List<SlackFileDto>();
        var fileReferences = new List<FileReference>();
        if (message?.Files != null)
            files = message.Files.Select(f => new SlackFileDto()
            {
                Url = f.PrivateUrl,
                Filename = f.Name
            }).ToList();

        if (message?.Files != null)
        {
            foreach (var f in message.Files)
            {
                var fileRequest = new SlackRequest(f.PrivateUrl, Method.Get, Creds);
                var fileResponse = Client.Get(fileRequest);
                using (var stream = new MemoryStream(fileResponse.RawBytes!))
                {
                    var file = FileManagementClient.UploadAsync(stream, fileResponse.ContentType, new Uri(f.PrivateUrl).Segments.Last()).Result;
                    fileReferences.Add(file);
                }
            }            
        }

        return new()
        {
            MessageText = message?.Text,
            FilesUrls = files,
            ChannelId = input.ChannelId,
            Timestamp = input.Timestamp,
            User = message?.User,
            Files = fileReferences,
        };
    }

    [Action("Update message", Description = "Update a specific message in a Slack channel")]
    public Task<MessageEntity> UpdateMessage([ActionParameter] UpdateMessageParameters input)
    {
        var request = new SlackRequest("/chat.update", Method.Post, Creds)
            .WithJsonBody(input, JsonConfig.Settings);

        return Client.ExecuteWithErrorHandling<MessageEntity>(request);
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