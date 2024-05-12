using WebLibrary.Backend.Models.DTO.Requests.Reader;
using WebLibrary.Backend.Models.DTO.Responses.Reader;
using WebLibraryService.Backend.Domain.Interfaces;

namespace WebLibraryService.Backend.Domain;

public class ReaderService : IReaderService
{
    public Task<Guid> CreateAsync(CreateReaderRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<List<GetReaderResponse>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<GetReaderResponse> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(UpdateReaderRequest request)
    {
        throw new NotImplementedException();
    }
}
