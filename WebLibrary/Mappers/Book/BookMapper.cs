using DbModels;
using WebLibrary.Mappers.Issue;
using WebLibrary.ModelRequest;
using WebLibrary.ModelResponse;
using WebLibrary.Requests;
using WebLibrary.Responses;

namespace WebLibrary.Mappers.Book;

public class BookMapper : IBookMapper
{
    /*
    private readonly IIssueMapper _issueMapper;

    public BookMapper(IIssueMapper issueMapper)
    {
        _issueMapper = issueMapper;
    }*/

    public DbBook Map(CreateBookRequest bookRequest)
    {
        DbBook book = new()
        {
            Id = Guid.NewGuid(),
            Title = bookRequest.Title,
            Author = bookRequest.Author,
            NumberPages = bookRequest.NumberPages,
            YearPublishing = bookRequest.YearPublishing,
            CityPublishing = bookRequest.CityPublishing,
            HallNo = bookRequest.HallNo
        };

        return book;
    }

    public GetBookResponse Map(DbBook book)
    {
        GetBookResponse bookResponse = new()
        {
            Title = book.Title,
            Author = book.Author,
            NumberPages = book.NumberPages,
            YearPublishing = book.YearPublishing,
            CityPublishing = book.CityPublishing,
            HallNo = book.HallNo,
            IssueId = book.IssueId,
            //Issue = _issueMapper.Map(book.Issue)
        };

        return bookResponse;
    }
}