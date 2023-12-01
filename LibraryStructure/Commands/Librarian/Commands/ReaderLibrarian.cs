using DbModels;
using LibraryStructure.Commands.Librarian.Interfaces;
using LibraryStructure.Validators.Librarian;
using Provider.Repositories.Librarian;
using ServiceModels.Requests.Librarian;
using ServiceModels.Responses.Librarian;
using WebLibrary.Mappers.Librarian;

namespace LibraryStructure.Commands.Librarian.Commands;

public class ReaderLibrarian : LibrarianActions, IReaderLibrarian
{
    public ReaderLibrarian(ILibrarianRepository LibrarianRepository, ICreateLibrarianRequestValidator validator, ILibrarianMapper mapper)
    : base(LibrarianRepository, validator, mapper)
    {
    }

    public GetLibrariansResponse Get()
    {
        List<DbLibrarian> dbLibrarians = _LibrarianRepository.Get().ToList();

        GetLibrariansResponse LibrarianResponse = new()
        {
            LibrarianResponses = dbLibrarians.Select(u => _mapper.Map(u)).ToList()
        };

        return LibrarianResponse;
    }
    public async Task<GetLibrarianResponse> GetAsync(GetLibrarianRequest request)
    {
        DbLibrarian? Librarian = await _LibrarianRepository.GetAsync(request.Id);

        if (Librarian is null)
        {
            GetLibrarianResponse LibrarianResponse = new()
            {
                Error = NOT_FOUND
            };

            return LibrarianResponse;
        }

        return _mapper.Map(Librarian);
    }
}