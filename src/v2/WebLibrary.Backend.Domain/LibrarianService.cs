using WebLibrary.Backend.Models.DTO.Requests.Librarian;
using WebLibrary.Backend.Models.DTO.Responses.Librarian;
using WebLibraryService.Backend.Domain.Interfaces;

namespace WebLibraryService.Backend.Domain;

public class LibrarianService : ILibrarianService
{
    public Task<Guid> CreateAsync(CreateLibrarianRequest request, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<List<GetLibrarianResponse>> GetAllAsync(CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<GetLibrarianResponse> GetAsync(Guid id, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(UpdateLibrarianRequest request, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}
