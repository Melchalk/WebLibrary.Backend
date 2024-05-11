using ServiceModels.Requests.Librarian;
using ServiceModels.Responses.Librarian;

namespace WebLibrarianService.Backend.Domain.Interfaces;

public interface ILibrarianService
{
    Task<Guid> CreateAsync(CreateLibrarianRequest request);

    Task<GetLibrarianResponse> GetAsync(Guid id);

    Task<List<GetLibrarianResponse>> GetAllAsync();

    Task UpdateAsync(UpdateLibrarianRequest request);

    Task DeleteAsync(Guid id);
}
