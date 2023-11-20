using DbModels;
using WebLibrary.ModelRequest;
using WebLibrary.ModelResponse;

namespace WebLibrary.Mappers.Issue;

public interface IIssueMapper
{
    DbIssue Map(IssueRequest issueRequest);

    IssueResponse? Map(DbIssue? dbIssue);
}
