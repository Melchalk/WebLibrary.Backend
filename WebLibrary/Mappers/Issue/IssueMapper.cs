using DbModels;
using ServiceModels.Requests.Issue;
using ServiceModels.Responses.Issue;
using WebLibrary.Mappers.Book;

namespace WebLibrary.Mappers.Issue;

public class IssueMapper : IIssueMapper
{
    private readonly IBookMapper _bookMapper;
    public IssueMapper(IBookMapper bookMapper)
    {
        _bookMapper = bookMapper;
    }

    public DbIssue Map(CreateIssueRequest issueRequest)
    {
        DbIssue issue = new()
        {
            Id = Guid.NewGuid(),
            ReaderId = issueRequest.ReaderId,
            DateIssue = issueRequest.DateIssue,
            Period = issueRequest.Period,
        };

        return issue;
    }

    public GetIssueResponse? Map(DbIssue? issue)
    {
        if (issue is null)
        {
            return null;
        }

        GetIssueResponse issueResponse = new()
        {
            Id = issue.Id,
            ReaderId = issue.ReaderId,
            DateIssue = issue.DateIssue,
            Period = issue.Period,
            Books = issue.Books.Select(a => _bookMapper.Map(a)).ToList(),
        };

        return issueResponse;
    }
}