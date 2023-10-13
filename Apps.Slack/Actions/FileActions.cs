using System.Net.Mime;
using Apps.Slack.Api;
using Apps.Slack.Invocables;
using Apps.Slack.Models.Entities;
using Apps.Slack.Models.Requests.File;
using Apps.Slack.Models.Requests.Message;
using Apps.Slack.Models.Responses.File;
using Apps.Slack.Models.Responses.Message;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Utils.Extensions.String;
using RestSharp;

namespace Apps.Slack.Actions;

public class FileActions : SlackInvocable
{
    public FileActions(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    [Action("Get message files", Description = "Get message files by timestamp")]
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
                Url = f.PrivateUrl, Filename = f.Name
            }).ToList();

        return new()
        {
            MessageText = message.Text, FilesUrls = files
        };
    }


    [Action("Upload file", Description = "Upload a file to channel")]
    public async Task<FileEntity> UploadFile([ActionParameter] UploadFileRequest input)
    {
        var request = new SlackRequest("/files.upload", Method.Post, Creds)
            .AddParameter("channels", input.ChannelId)
            .AddParameter("filename", input.File.Name)
            .AddFile("file", input.File.Bytes, input.File.Name);

        var response = await Client.ExecuteWithErrorHandling<UploadFileResponse>(request);
        return response.File;
    }

    [Action("Get file info", Description = "Get information about a file")]
    public async Task<FileEntity> GetFileInfo([ActionParameter] GetFileInfoParameters input)
    {
        var request = new SlackRequest("/files.info", Method.Get, Creds)
            .AddParameter("file", input.FileId);

        var response = await Client.ExecuteWithErrorHandling<GetFileInfoResponse>(request);
        return response.File;
    }

    [Action("Download file", Description = "Download file by url")]
    public DownloadFileResponse DownloadFile([ActionParameter] DownloadFileRequest input)
    {
        var request = new SlackRequest(input.Url, Method.Get, Creds);

        return new()
        {
            File = new(Client.Get(request).RawBytes!)
            {
                Name = input.Url.ToUri().Segments.Last(),
                ContentType = MediaTypeNames.Application.Octet
            }
        };
    }

    [Action("Delete file", Description = "Delete a file")]
    public Task DeleteFile([ActionParameter] DeleteFileParameters input)
    {
        var request = new SlackRequest("/files.delete", Method.Post, Creds)
            .AddParameter("file", input.FileId);

        return Client.ExecuteWithErrorHandling(request);
    }
}