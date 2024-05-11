using ServiceModels.Requests.Book;
using ServiceModels.Responses.Book;

namespace WebLibraryService.Backend.Domain.Interfaces;

public interface IBookService
{
    Task<Guid> CreateAsync(CreateBookRequest request);

    Task<GetReaderResponse> GetAsync(Guid id);

    Task<List<GetReaderResponse>> GetAllAsync();

    Task UpdateAsync(UpdateBookRequest request);

    Task DeleteAsync(Guid id);
}
