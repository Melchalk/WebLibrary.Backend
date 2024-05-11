namespace WebLibrary.Backend.Models.DTO.Requests.Issue;

public class CreateIssueRequest
{
    public Guid ReaderId { get; set; }
    public uint Period { get; set; }

    public required List<Guid> BooksId { get; set; }
}