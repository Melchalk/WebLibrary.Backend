using DbModels;
using WebLibrary.Mappers.Book;
using WebLibrary.Mappers.Reader;
using WebLibrary.ModelRequest;
using WebLibrary.ModelResponse;

namespace WebLibrary.Mappers.Issue;

public class IssueMapper : IIssueMapper
{
    private readonly IBookMapper _bookMapper;
    //private readonly IReaderMapper _readerMapper;

    public IssueMapper(IBookMapper bookMapper)
    {
        _bookMapper = bookMapper;
        //_readerMapper = readerMapper;
    }

    public DbIssue Map(IssueRequest issueRequest)
    {
        DbIssue issue = new()
        {
            Id = Guid.NewGuid(),
            ReaderId = issueRequest.ReaderId,
            DateIssue = issueRequest.DateIssue,
            Period = issueRequest.Period,
            Books = issueRequest.Books.Select(a => _bookMapper.Map(a)).ToList(),
            //Reader = _readerMapper.Map(issueRequest.Reader)
        };

        return issue;
    }

    public IssueResponse? Map(DbIssue? dbIssue)
    {
        if (dbIssue is null)
        {
            return null;
        }

        IssueResponse issueResponse = new()
        {
            Id = dbIssue.Id,
            ReaderId = dbIssue.ReaderId,
            DateIssue = dbIssue.DateIssue,
            Period = dbIssue.Period,
            Books = dbIssue.Books.Select(a => _bookMapper.Map(a)).ToList(),
            //Reader = _readerMapper.Map(dbIssue.Reader)
        };

        return issueResponse;
    }
}
