using DbModels;
using ServiceModels.Requests.Librarian;
using ServiceModels.Responses.Librarian;

namespace WebLibrary.Mappers.Librarian;

public class LibrarianMapper : ILibrarianMapper
{
    public DbLibrarian Map(CreateLibrarianRequest librarianRequest)
    {
        DbLibrarian librarian = new()
        {
            Id = Guid.NewGuid(),
            Fullname = librarianRequest.Fullname,
            Telephone = librarianRequest.Telephone,
            LibraryId = librarianRequest.LibraryId,
        };

        return librarian;
    }

    public GetLibrarianResponse Map(DbLibrarian librarian)
    {
        GetLibrarianResponse librarianResponse = new()
        {
            Id = librarian.Id,
            Fullname = librarian.Fullname,
            Telephone = librarian.Telephone,
            LibraryId = librarian.LibraryId,
        };

        return librarianResponse;
    }
}