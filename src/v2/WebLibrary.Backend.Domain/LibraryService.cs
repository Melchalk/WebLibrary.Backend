using WebLibrary.Backend.Models.DTO.Requests.Library;
using WebLibrary.Backend.Models.DTO.Responses.Library;
using WebLibraryService.Backend.Domain.Interfaces;

namespace WebLibraryService.Backend.Domain;

public class LibraryService : ILibraryService
{
    public Task<Guid> CreateAsync(CreateLibraryRequest request, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<List<GetLibraryResponse>> GetAllAsync(CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<GetLibraryResponse> GetAsync(Guid id, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(UpdateLibraryRequest request, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}
