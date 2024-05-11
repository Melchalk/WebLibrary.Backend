using WebLibrary.Backend.Models.DTO.Requests.Librarian;
using WebLibrary.Backend.Models.DTO.Responses.Librarian;
using WebLibraryService.Backend.Domain.Interfaces;

namespace WebLibraryService.Backend.Domain;

public class LibrarianService : ILibrarianService
{
    public Task<Guid> CreateAsync(CreateLibrarianRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<List<GetLibrarianResponse>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<GetLibrarianResponse> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(UpdateLibrarianRequest request)
    {
        throw new NotImplementedException();
    }
}
