using DbModels;
using WebLibrary.Requests;
using WebLibrary.Responses;

namespace WebLibrary.Mappers.Book;

public interface IBookMapper
{
    DbBook Map(CreateBookRequest bookRequest);

    GetBookResponse Map(DbBook dbBook);
}
