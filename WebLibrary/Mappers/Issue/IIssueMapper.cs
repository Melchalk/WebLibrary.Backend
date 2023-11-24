using DbModels;
using WebLibrary.ModelRequest;
using WebLibrary.ModelResponse;
using WebLibrary.Requests;

namespace WebLibrary.Mappers.Issue;

public interface IIssueMapper
{
    DbIssue Map(CreateIssueRequest issueRequest);

    GetIssueResponse? Map(DbIssue? dbIssue);
}
