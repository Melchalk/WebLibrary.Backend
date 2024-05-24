using DbModels;
using ServiceModels.Requests.Library;
using ServiceModels.Responses.Library;
using WebLibrary.Mappers.Hall;
using WebLibrary.Mappers.Librarian;

namespace WebLibrary.Mappers.Library;

public class LibraryMapper : ILibraryMapper
{
    private readonly IHallMapper _hallMapper;
    private readonly ILibrarianMapper _librarianMapper;

    public LibraryMapper(IHallMapper hallMapper, ILibrarianMapper librarianMapper)
    {
        _hallMapper = hallMapper;
        _librarianMapper = librarianMapper;
    }

    public DbLibrary Map(CreateLibraryRequest libraryRequest)
    {
        DbLibrary library = new()
        {
            Id = Guid.NewGuid(),
            Title = libraryRequest.Title,
            Address = libraryRequest.Address,
            Telephone = libraryRequest.Telephone,
        };

        return library;
    }

    public GetLibraryResponse? Map(DbLibrary? library)
    {
        if (library is null)
        {
            return null;
        }

        GetLibraryResponse libraryResponse = new()
        {
            Id = library.Id,
            Title = library.Title,
            Address = library.Address,
            Telephone = library.Telephone,
            Librarians = library.Librarians.Select(a => _librarianMapper.Map(a)).ToList(),
            Halls = library.Halls.Select(a => _hallMapper.Map(a)).ToList(),
        };

        return libraryResponse;
    }
}