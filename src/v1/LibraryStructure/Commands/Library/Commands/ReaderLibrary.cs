using DbModels;
using LibraryStructure.Commands.Library.Interfaces;
using LibraryStructure.Validators.Library;
using Provider.Repositories.Library;
using ServiceModels.Requests.Library;
using ServiceModels.Responses.Library;
using WebLibrary.Mappers.Library;

namespace LibraryStructure.Commands.Library.Commands;

public class ReaderLibrary : LibraryActions, IReaderLibrary
{
    public ReaderLibrary(ILibraryRepository libraryRepository, ICreateLibraryRequestValidator validator, ILibraryMapper mapper)
        : base(libraryRepository, validator, mapper)
    {
    }

    public GetLibrariesResponse Get()
    {
        List<DbLibrary> dbLibrarys = _libraryRepository.Get().ToList();

        GetLibrariesResponse libraryResponse = new()
        {
            LibraryResponses = dbLibrarys.Select(u => _mapper.Map(u)).ToList()
        };

        return libraryResponse;
    }

    public async Task<GetLibraryResponse> GetAsync(GetLibraryRequest request)
    {
        DbLibrary? library = await _libraryRepository.GetAsync(request.Id);

        if (library is null)
        {
            GetLibraryResponse libraryResponse = new()
            {
                Error = NOT_FOUND
            };

            return libraryResponse;
        }

        return _mapper.Map(library);
    }
}