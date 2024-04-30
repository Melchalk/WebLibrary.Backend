using DbModels;
using ServiceModels.Requests.Library;
using ServiceModels.Responses.Library;

namespace WebLibrary.Mappers.Library;

public interface ILibraryMapper
{
    DbLibrary Map(CreateLibraryRequest libraryRequest);

    GetLibraryResponse? Map(DbLibrary? dbLibrary);
}