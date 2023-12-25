using System.Net.Mime;
using Apps.Slack.Api;
using Apps.Slack.Invocables;
using Apps.Slack.Models.Requests.File;
using Apps.Slack.Models.Responses.File;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Files;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.SDK.Extensions.FileManagement.Interfaces;
using RestSharp;

namespace Apps.Slack.Actions;

[ActionList]
public class FileActions : SlackInvocable
{
    private IFileManagementClient FileManagementClient { get; set; }

    public FileActions(InvocationContext invocationContext, IFileManagementClient fileManagementClient) : base(invocationContext)
    {
        FileManagementClient = fileManagementClient;
    }

    [Action("Download file", Description = "Download file by url")]
    public DownloadFileResponse DownloadFile([ActionParameter] DownloadFileRequest input)
    {
        var request = new SlackRequest(input.Url, Method.Get, Creds);
        var response = Client.Get(request);
        FileReference file = null;
        using (var stream = new MemoryStream(response.RawBytes!))
        {
            file = FileManagementClient.UploadAsync(stream, MediaTypeNames.Text.Plain, new Uri(input.Url).Segments.Last()).Result;
        }
        return new() { File = file };
    }
}