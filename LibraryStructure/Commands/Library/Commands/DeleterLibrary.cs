using DbModels;
using LibraryStructure.Commands.Library.Interfaces;
using LibraryStructure.Validators.Library;
using Provider.Repositories.Library;
using ServiceModels.Requests.Library;
using ServiceModels.Responses.Library;

namespace LibraryStructure.Commands.Library.Commands;

public class DeleterLibrary : LibraryActions, IDeleterLibrary
{
    public DeleterLibrary(ILibraryRepository LibraryRepository, ICreateLibraryRequestValidator validator, ILibraryMapper mapper)
    : base(LibraryRepository, validator, mapper)
    {
    }

    public async Task<DeleteLibraryResponse> DeleteAsync(DeleteLibraryRequest request)
    {
        DeleteLibraryResponse LibraryResponse = new();

        Guid id = request.Id;

        DbLibrary? Library = await _LibraryRepository.GetAsync(id);

        if (Library is null)
        {
            LibraryResponse.Error = NOT_FOUND;

            return LibraryResponse;
        }

        await _LibraryRepository.DeleteAsync(Library);

        LibraryResponse.Result = true;

        return LibraryResponse;
    }
}
