using DbModels;
using LibraryStructure.Commands.Librarian.Interfaces;
using LibraryStructure.Validators.Librarian;
using ServiceModels.Requests.Librarian;
using ServiceModels.Responses.Librarian;
using WebLibrary.Backend.Provider.Repositories.Interfaces;
using WebLibrary.Mappers.Librarian;

namespace LibraryStructure.Commands.Librarian.Commands;

public class ReadLibrarianCommand : LibrarianActions, IReaderLibrarian
{
    public ReadLibrarianCommand(ILibrarianRepository librarianRepository, ICreateLibrarianRequestValidator validator, ILibrarianMapper mapper)
        : base(librarianRepository, validator, mapper)
    {
    }

    public GetLibrariansResponse Get()
    {
        List<DbLibrarian> dbLibrarians = _librarianRepository.Get().ToList();

        GetLibrariansResponse librarianResponse = new()
        {
            LibrarianResponses = dbLibrarians.Select(u => _mapper.Map(u)).ToList()
        };

        return librarianResponse;
    }
    public async Task<GetLibrarianResponse> GetAsync(GetLibrarianRequest request)
    {
        DbLibrarian? librarian = await _librarianRepository.GetAsync(request.Id);

        if (librarian is null)
        {
            GetLibrarianResponse LibrarianResponse = new()
            {
                Error = NOT_FOUND
            };

            return LibrarianResponse;
        }

        return _mapper.Map(librarian);
    }
}