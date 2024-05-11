namespace ServiceModels.Requests.Issue;

public class UpdateIssueRequest
{
    public Guid Id { get; set; }
    public uint? AddPeriod { get; set; }

    public List<Guid>? BooksId { get; set; }
}