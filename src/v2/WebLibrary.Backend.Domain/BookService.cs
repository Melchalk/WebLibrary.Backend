using ServiceModels.Requests.Book;
using ServiceModels.Responses.Book;
using WebLibraryService.Backend.Domain.Interfaces;

namespace WebLibraryService.Backend.Domain;

public class BookService : IBookService
{
    public Task<Guid> CreateAsync(CreateBookRequest request)
    {
        throw new NotImplementedException();
    }
    public Task<List<GetBookResponse>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<GetBookResponse> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(UpdateBookRequest request)
    {
        throw new NotImplementedException();
    }
}
