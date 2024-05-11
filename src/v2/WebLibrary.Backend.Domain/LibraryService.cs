using WebLibrary.Backend.Models.DTO.Requests.Library;
using WebLibrary.Backend.Models.DTO.Responses.Library;
using WebLibraryService.Backend.Domain.Interfaces;

namespace WebLibraryService.Backend.Domain;

public class LibraryService : ILibraryService
{
    public Task<Guid> CreateAsync(CreateLibraryRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<List<GetLibraryResponse>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<GetLibraryResponse> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(UpdateLibraryRequest request)
    {
        throw new NotImplementedException();
    }
}
