namespace ServiceModels.Responses.Issue;

public class UpdateIssueResponse
{
    public bool Result { get; set; }
    public List<string>? Errors { get; set; }
}