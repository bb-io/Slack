namespace Apps.Slack.Models;

public class UploadFileDto
{
    public string ChannelId { get; set; }
    
    public byte[] File { get; set; }

    public string FileName { get; set; }

    public string FileType { get; set; }
}