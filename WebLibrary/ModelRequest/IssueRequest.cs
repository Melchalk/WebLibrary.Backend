namespace WebLibrary.ModelRequest;

public class IssueRequest
{
    public Guid ReaderId { get; set; }
    public DateTime DateIssue { get; set; }
    public int Period { get; set; }

    public List<BookRequest> Books { get; set; }
    public ReaderRequest Reader { get; set; }
}
