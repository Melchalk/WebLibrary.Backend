using DbModels;
using ServiceModels.Requests.Librarian;
using ServiceModels.Responses.Librarian;

namespace WebLibrary.Mappers.Librarian;

public interface ILibrarianMapper
{
    DbLibrarian Map(CreateLibrarianRequest librarianRequest);

    GetLibrarianResponse Map(DbLibrarian dbLibrarian);
}