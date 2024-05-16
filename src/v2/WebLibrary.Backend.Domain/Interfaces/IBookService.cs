using WebLibrary.Backend.Models.DTO.Requests.Book;
using WebLibrary.Backend.Models.DTO.Responses.Book;

namespace WebLibraryService.Backend.Domain.Interfaces;

public interface IBookService
{
    Task<Guid> CreateAsync(CreateBookRequest request, CancellationToken token);

    Task<GetBookResponse> GetAsync(Guid id, CancellationToken token);

    Task<List<GetBookResponse>> GetAllAsync(int libraryNumber, CancellationToken token)

    Task UpdateAsync(UpdateBookRequest request, CancellationToken token);

    Task DeleteAsync(Guid id, CancellationToken token);
}
