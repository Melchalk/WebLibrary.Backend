namespace ServiceModels.Responses.Issue;

public class CreateIssueResponse
{
    public Guid? Id { get; set; }

    public List<string>? Errors { get; set; }
}
