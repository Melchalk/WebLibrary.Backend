using ServiceModels.Responses.Book;

namespace ServiceModels.Responses.Issue;

public class GetIssueResponse
{
    public Guid Id { get; set; }
    public Guid ReaderId { get; set; }
    public DateTime DateIssue { get; set; }
    public int Period { get; set; }

    public required List<GetBookResponse> Books { get; set; }
}