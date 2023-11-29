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
    public ReaderLibrary(ILibraryRepository LibraryRepository, ICreateLibraryRequestValidator validator, ILibraryMapper mapper)
    : base(LibraryRepository, validator, mapper)
    {
    }

    public GetLibrariesResponse Get()
    {
        List<DbLibrary> dbLibrarys = _LibraryRepository.Get().ToList();

        GetLibrariesResponse LibraryResponse = new()
        {
            LibraryResponses = dbLibrarys.Select(u => _mapper.Map(u)).ToList()
        };

        return LibraryResponse;
    }

    public async Task<GetLibraryResponse> GetAsync(GetLibraryRequest request)
    {
        DbLibrary? Library = await _LibraryRepository.GetAsync(request.Id);

        GetLibraryResponse LibraryResponse = new();

        if (Library is null)
        {
            LibraryResponse.Error = NOT_FOUND;

            return LibraryResponse;
        }

        return _mapper.Map(Library);
    }
}