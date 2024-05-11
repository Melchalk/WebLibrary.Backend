using WebLibrary.Backend.Models.DTO.Requests.Reader;
using WebLibrary.Backend.Models.DTO.Responses.Book;

namespace WebLibraryService.Backend.Domain.Interfaces;

public interface IReaderService
{
    Task<Guid> CreateAsync(CreateReaderRequest request);

    Task<GetReaderResponse> GetAsync(Guid id);

    Task<List<GetReaderResponse>> GetAllAsync();

    Task UpdateAsync(UpdateReaderRequest request);

    Task DeleteAsync(Guid id);
}
