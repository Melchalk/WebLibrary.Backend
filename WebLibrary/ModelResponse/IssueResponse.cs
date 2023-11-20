namespace WebLibrary.ModelResponse;

public class IssueResponse
{
    public Guid Id { get; set; }
    public Guid ReaderId { get; set; }
    public DateTime DateIssue { get; set; }
    public int Period { get; set; }

    public List<BookResponse> Books { get; set; }
    //public ReaderResponse Reader { get; set; }
}
