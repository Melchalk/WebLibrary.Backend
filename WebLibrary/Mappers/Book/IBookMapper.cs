using DbModels;
using WebLibrary.ModelRequest;
using WebLibrary.ModelResponse;

namespace WebLibrary.Mappers.Book;

public interface IBookMapper
{
    DbBook Map(BookRequest bookRequest);

    BookResponse Map(DbBook dbBook);
}
