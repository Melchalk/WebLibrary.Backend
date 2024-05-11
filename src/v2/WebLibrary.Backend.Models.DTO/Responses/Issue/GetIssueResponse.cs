using WebLibrary.Backend.Models.DTO.Responses.Book;

namespace WebLibrary.Backend.Models.DTO.Responses.Issue;

public class GetIssueResponse
{
    public Guid Id { get; set; }
    public Guid ReaderId { get; set; }
    public DateTime ReturnDate { get; set; }

    public required List<GetReaderResponse> Books { get; set; }
}