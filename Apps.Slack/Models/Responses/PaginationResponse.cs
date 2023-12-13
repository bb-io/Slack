namespace Apps.Slack.Models.Responses;

public class PaginationResponse<T>
{
    public virtual IEnumerable<T> Items { get; set; }
    
    public PaginationMetadata? ResponseMetadata { get; set; }
}