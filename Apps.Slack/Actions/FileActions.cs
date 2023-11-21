using System.Net.Mime;
using Apps.Slack.Api;
using Apps.Slack.Invocables;
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
}