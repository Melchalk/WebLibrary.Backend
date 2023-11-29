using DbModels;
using ServiceModels.Requests.Book;
using ServiceModels.Responses.Book;

namespace WebLibrary.Mappers.Book;

public class BookMapper : IBookMapper
{
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
        };

        return bookResponse;
    }
}