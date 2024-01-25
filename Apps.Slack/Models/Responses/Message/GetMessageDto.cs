using Apps.Slack.Models.Entities;

namespace Apps.Slack.Models.Responses.Message;

public class GetMessageDto
{
    public IEnumerable<FileMessageDto> Messages { get; set; }
}

public class FileMessageDto
{
    public string Text { get; set; }

    public string Type { get; set; }
    public string User { get; set; }
    public string Ts { get; set; }

    public IEnumerable<FileEntity>? Files { get; set; }
}