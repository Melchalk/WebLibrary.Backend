namespace ServiceModels.Requests.Issue;

public class UpdateIssueRequest
{
    public Guid Id { get; set; }
    public CreateIssueRequest CreateIssueRequest { get; set; }
}
