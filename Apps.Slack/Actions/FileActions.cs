using Apps.Slack.Invocables;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.SDK.Extensions.FileManagement.Interfaces;

namespace Apps.Slack.Actions;

[ActionList]
public class FileActions(InvocationContext invocationContext, IFileManagementClient fileManagementClient)
    : SlackInvocable(invocationContext)
{
    private IFileManagementClient FileManagementClient { get; set; } = fileManagementClient;

    //[Action("Download file", Description = "Download file by url")]
    //public DownloadFileResponse DownloadFile([ActionParameter] DownloadFileRequest input)
    //{
    //    var request = new SlackRequest(input.Url, Method.Get, Creds);
    //    var response = Client.Get(request);
    //    FileReference file = null;
    //    using (var stream = new MemoryStream(response.RawBytes!))
    //    {
    //        file = FileManagementClient.UploadAsync(stream, response.ContentType, new Uri(input.Url).Segments.Last()).Result;
    //    }
    //    return new() { File = file };
    //}
}