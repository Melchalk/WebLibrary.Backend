namespace ServiceModels.Requests;

public class CreateIssueRequest
{
    public Guid ReaderId { get; set; }
    public DateTime DateIssue { get; set; }
    public int Period { get; set; }

    public List<CreateBookRequest> Books { get; set; }
    public CreateReaderRequest Reader { get; set; }
}
