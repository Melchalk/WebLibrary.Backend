namespace ServiceModels.Responses;

public class GetIssueResponse
{
    public Guid Id { get; set; }
    public Guid ReaderId { get; set; }
    public DateTime DateIssue { get; set; }
    public int Period { get; set; }

    public List<GetBookResponse> Books { get; set; }
}
