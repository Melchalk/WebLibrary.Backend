using DbModels;
using LibraryStructure.Commands.Librarian.Interfaces;
using Provider.Repositories.Librarian;
using ServiceModels.Requests.Librarian;
using ServiceModels.Responses.Librarian;
using WebLibrary.Mappers.Librarian;
using WebLibrary.Validators.Librarian;

namespace LibraryStructure.Commands.Librarian.Commands;

public class DeleterLibrarian : LibrarianActions, IDeleterLibrarian
{
    public DeleterLibrarian(ILibrarianRepository LibrarianRepository, ICreateLibrarianRequestValidator validator, ILibrarianMapper mapper)
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
