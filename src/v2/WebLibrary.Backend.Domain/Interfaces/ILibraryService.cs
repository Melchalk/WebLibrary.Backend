using WebLibrary.Backend.Models.DTO.Requests.Library;
using WebLibrary.Backend.Models.DTO.Responses.Library;

namespace WebLibraryService.Backend.Domain.Interfaces;

public interface ILibraryService
{
    Task<Guid> CreateAsync(CreateLibraryRequest request, CancellationToken token);

    Task<GetLibraryResponse> GetAsync(Guid id, CancellationToken token);

    Task<List<GetLibraryResponse>> GetAllAsync(CancellationToken token);

    Task UpdateAsync(UpdateLibraryRequest request, CancellationToken token);

    Task DeleteAsync(Guid id, CancellationToken token);
}
