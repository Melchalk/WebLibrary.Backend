using DbModels;
using Provider.Repositories.Reader;
using ServiceModels.Requests.Reader;
using ServiceModels.Responses.Reader;
using WebLibrary.Commands.Reader.Interfaces;
using WebLibrary.Mappers.Reader;
using WebLibrary.Validators.Reader;

namespace WebLibrary.Commands.Reader.Commands;

public class DeleterReader : ReaderActions, IDeleterReader
{
    public DeleterReader(IReaderRepository readerRepository, ICreateReaderRequestValidator validator, IReaderMapper mapper)
    : base(readerRepository, validator, mapper)
    {
    }

    public async Task<DeleteReaderResponse> DeleteAsync(DeleteReaderRequest request)
    {
        DeleteReaderResponse readerResponse = new();

        Guid id = request.Id;

        DbReader? reader = await _readerRepository.GetAsync(id);

        if (reader is null)
        {
            readerResponse.Error = NOT_FOUND;

            return readerResponse;
        }

        await _readerRepository.DeleteAsync(reader);

        readerResponse.Result = true;

        return readerResponse;
    }
}
