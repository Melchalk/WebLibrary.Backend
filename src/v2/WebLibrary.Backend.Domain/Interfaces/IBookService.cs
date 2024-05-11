using WebLibrary.Backend.Models.DTO.Requests.Book;
using WebLibrary.Backend.Models.DTO.Responses.Book;

namespace WebLibraryService.Backend.Domain.Interfaces;

public interface IBookService
{
    Task<Guid> CreateAsync(CreateBookRequest request);

    Task<GetBookResponse> GetAsync(Guid id);

    Task<List<GetBookResponse>> GetAllAsync();

    Task UpdateAsync(UpdateBookRequest request);

    Task DeleteAsync(Guid id);
}
