using WebLibrary.Backend.Models.DTO.Requests.Librarian;
using WebLibrary.Backend.Models.DTO.Responses.Librarian;

namespace WebLibraryService.Backend.Domain.Interfaces;

public interface ILibrarianService
{
    Task<Guid> CreateAsync(CreateLibrarianRequest request, CancellationToken token);

    Task<GetLibrarianResponse> GetAsync(Guid id, CancellationToken token);

    Task<List<GetLibrarianResponse>> GetAllAsync(CancellationToken token);

    Task UpdateAsync(UpdateLibrarianRequest request, CancellationToken token);

    Task DeleteAsync(Guid id, CancellationToken token);
}
