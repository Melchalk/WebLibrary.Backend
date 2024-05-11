using WebLibrary.Backend.Models.DTO.Requests.Librarian;
using WebLibrary.Backend.Models.DTO.Responses.Librarian;

namespace WebLibraryService.Backend.Domain.Interfaces;

public interface ILibrarianService
{
    Task<Guid> CreateAsync(CreateLibrarianRequest request);

    Task<GetLibrarianResponse> GetAsync(Guid id);

    Task<List<GetLibrarianResponse>> GetAllAsync();

    Task UpdateAsync(UpdateLibrarianRequest request);

    Task DeleteAsync(Guid id);
}
