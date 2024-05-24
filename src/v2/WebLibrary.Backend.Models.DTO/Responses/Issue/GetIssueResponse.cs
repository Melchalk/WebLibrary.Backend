namespace WebLibrary.Backend.Models.DTO.Responses.Issue;

public class GetIssueResponse
{
    public Guid Id { get; set; }
    public Guid ReaderId { get; set; }
    public DateTime ReturnDate { get; set; }

    public required List<Guid> BooksId { get; set; }
}