using DbModels;
using Provider.Repositories.Reader;
using ServiceModels.Requests.Reader;
using ServiceModels.Responses.Reader;
using WebLibrary.Commands.Reader.Interfaces;
using WebLibrary.Mappers.Reader;
using WebLibrary.Validators.Reader;

namespace WebLibrary.Commands.Reader.Commands;

public class ReaderReader : ReaderActions, IReaderReader
{
    public ReaderReader(IReaderRepository readerRepository, ICreateReaderRequestValidator validator, IReaderMapper mapper)
        : base(readerRepository, validator, mapper)
    {
    }

    public GetReadersResponse Get()
    {
        List<DbReader> dbReaders = _readerRepository.Get().ToList();

        GetReadersResponse readerResponse = new()
        {
            ReaderResponses = dbReaders.Select(u => _mapper.Map(u)).ToList()
        };

        return readerResponse;
    }
    public async Task<GetReaderResponse> GetAsync(GetReaderRequest request)
    {
        DbReader? reader = await _readerRepository.GetAsync(request.Id);

        GetReaderResponse readerResponse = new();

        if (reader is null)
        {
            readerResponse.Error = NOT_FOUND;

            return readerResponse;
        }

        return _mapper.Map(reader);
    }
}