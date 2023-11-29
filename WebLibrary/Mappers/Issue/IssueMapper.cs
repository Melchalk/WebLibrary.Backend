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
            Books = issueRequest.Books.Select(a => _bookMapper.Map(a)).ToList(),
        };

        return issue;
    }

    public GetIssueResponse? Map(DbIssue? dbIssue)
    {
        if (dbIssue is null)
        {
            return null;
        }

        GetIssueResponse issueResponse = new()
        {
            Id = dbIssue.Id,
            ReaderId = dbIssue.ReaderId,
            DateIssue = dbIssue.DateIssue,
            Period = dbIssue.Period,
            Books = dbIssue.Books.Select(a => _bookMapper.Map(a)).ToList(),
        };

        return issueResponse;
    }
}
