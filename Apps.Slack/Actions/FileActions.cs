﻿using System.Net.Mime;
using Apps.Slack.Api;
using Apps.Slack.Invocables;
using Apps.Slack.Models.Entities;
using Apps.Slack.Models.Requests.File;
using Apps.Slack.Models.Responses.File;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.Slack.Actions;

[ActionList]
public class FileActions : SlackInvocable
{
    public FileActions(InvocationContext invocationContext) : base(invocationContext)
    {
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
        var response = Client.Get(request);

        return new()
        {
            File = new(response.RawBytes!)
            {
                Name = new Uri(input.Url).Segments.Last(),
                ContentType = response.ContentType == MediaTypeNames.Text.Plain
                    ? MediaTypeNames.Application.Octet
                    : response.ContentType!
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