using ServiceModels.Responses.Book;

namespace ServiceModels.Responses.Issue;

public class GetIssueResponse
{
    public Guid Id { get; set; }
    public Guid ReaderId { get; set; }
    public DateTime ReturnDate { get; set; }

    public required List<GetReaderResponse> Books { get; set; }
}