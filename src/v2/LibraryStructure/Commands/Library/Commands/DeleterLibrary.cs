using DbModels;
using LibraryStructure.Commands.Library.Interfaces;
using LibraryStructure.Validators.Library;
using ServiceModels.Requests.Library;
using ServiceModels.Responses.Library;
using WebLibrary.Backend.Provider.Repositories.Interfaces;
using WebLibrary.Mappers.Library;

namespace LibraryStructure.Commands.Library.Commands;

public class DeleterLibrary : LibraryActions, IDeleterLibrary
{
    public DeleterLibrary(ILibraryRepository libraryRepository, ICreateLibraryRequestValidator validator, ILibraryMapper mapper)
        : base(libraryRepository, validator, mapper)
    {
    }

    public async Task<DeleteLibraryResponse> DeleteAsync(DeleteLibraryRequest request)
    {
        DeleteLibraryResponse libraryResponse = new();

        Guid id = request.Id;

        DbLibrary? Library = await _libraryRepository.GetAsync(id);

        if (Library is null)
        {
            libraryResponse.Error = NOT_FOUND;

            return libraryResponse;
        }

        await _libraryRepository.DeleteAsync(Library);

        libraryResponse.Result = true;

        return libraryResponse;
    }
}