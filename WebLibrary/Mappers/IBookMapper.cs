using DbModels;
using WebLibrary.ModelRequest;

namespace WebLibrary.Mappers;

public interface IBookMapper
{
    DbBook Map(BookRequest bookRequest);

    BookRequest Map(DbBook dbBook);
}
