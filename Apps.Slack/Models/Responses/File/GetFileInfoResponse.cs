using Apps.Slack.Models.Entities;

namespace Apps.Slack.Models.Responses.File;

public class GetFileInfoResponse
{
    public FileEntity File { get; set; }
    public string Content { get; set; }
    public string[] Comments { get; set; }
}