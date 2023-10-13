using Apps.Slack.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;


namespace Apps.Slack.Models.Requests.File;

public class UploadFileRequest
{
    [Display("Channel ID")]
    [DataSource(typeof(ChannelHandler))]
    public string ChannelId { get; set; }

    [Display("File")]
    public Blackbird.Applications.Sdk.Common.Files.File File { get; set; }
}