using DbModels;
using LibraryStructure.Commands.Librarian.Interfaces;
using LibraryStructure.Validators.Librarian;
using ServiceModels.Requests.Librarian;
using ServiceModels.Responses.Librarian;
using WebLibrary.Backend.Provider.Repositories.Interfaces;
using WebLibrary.Mappers.Librarian;

namespace LibraryStructure.Commands.Librarian.Commands;

public class DeleteLibrarianCommand : LibrarianActions, IDeleterLibrarian
{
    public DeleteLibrarianCommand(ILibrarianRepository librarianRepository, ICreateLibrarianRequestValidator validator, ILibrarianMapper mapper)
        : base(librarianRepository, validator, mapper)
    {
    }

    public async Task<DeleteLibrarianResponse> DeleteAsync(DeleteLibrarianRequest request)
    {
        DeleteLibrarianResponse librarianResponse = new();

        Guid id = request.Id;

        DbLibrarian? librarian = await _librarianRepository.GetAsync(id);

        if (librarian is null)
        {
            librarianResponse.Error = NOT_FOUND;

            return librarianResponse;
        }

        await _librarianRepository.DeleteAsync(librarian);

        librarianResponse.Result = true;

        return librarianResponse;
    }
}