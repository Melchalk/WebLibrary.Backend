using DbModels;
using WebLibrary.Requests;
using WebLibrary.Responses;

namespace WebLibrary.Mappers.Issue;

public interface IIssueMapper
{
    DbIssue Map(CreateIssueRequest issueRequest);

    GetIssueResponse? Map(DbIssue? dbIssue);
}
