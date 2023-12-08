using DbModels;
using LibraryStructure.Commands.Librarian.Interfaces;
using LibraryStructure.Validators.Librarian;
using Provider.Repositories.Librarian;
using ServiceModels.Requests.Librarian;
using ServiceModels.Responses.Librarian;
using WebLibrary.Mappers.Librarian;

namespace LibraryStructure.Commands.Librarian.Commands;

public class DeleteLibrarianCommand : LibrarianActions, IDeleterLibrarian
{
    public DeleteLibrarianCommand(ILibrarianRepository LibrarianRepository, ICreateLibrarianRequestValidator validator, ILibrarianMapper mapper)
        : base(LibrarianRepository, validator, mapper)
    {
    }

    public async Task<DeleteLibrarianResponse> DeleteAsync(DeleteLibrarianRequest request)
    {
        DeleteLibrarianResponse LibrarianResponse = new();

        Guid id = request.Id;

        DbLibrarian? Librarian = await _LibrarianRepository.GetAsync(id);

        if (Librarian is null)
        {
            LibrarianResponse.Error = NOT_FOUND;

            return LibrarianResponse;
        }

        await _LibrarianRepository.DeleteAsync(Librarian);

        LibrarianResponse.Result = true;

        return LibrarianResponse;
    }
}