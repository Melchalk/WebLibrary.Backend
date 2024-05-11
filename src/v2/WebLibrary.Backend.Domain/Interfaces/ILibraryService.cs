using ServiceModels.Requests.Library;
using ServiceModels.Responses.Library;

namespace WebLibraryService.Backend.Domain.Interfaces;

public interface ILibraryService
{
    Task<Guid> CreateAsync(CreateLibraryRequest request);

    Task<GetLibraryResponse> GetAsync(Guid id);

    Task<List<GetLibraryResponse>> GetAllAsync();

    Task UpdateAsync(UpdateLibraryRequest request);

    Task DeleteAsync(Guid id);
}
