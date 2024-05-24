using WebLibrary.Backend.Models.DTO.Requests.Library;
using WebLibrary.Backend.Models.DTO.Responses.Library;

namespace WebLibraryService.Backend.Domain.Interfaces;

public interface ILibraryService
{
    Task<int> CreateAsync(CreateLibraryRequest request, CancellationToken token);

    Task<GetLibraryResponse> GetAsync(int number, CancellationToken token);

    Task<List<GetLibraryResponse>> GetAllAsync(CancellationToken token);

    Task UpdateAsync(UpdateLibraryRequest request, CancellationToken token);

    Task DeleteAsync(int number, CancellationToken token);
}
