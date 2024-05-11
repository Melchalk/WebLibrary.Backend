using DbModels;
using ServiceModels.Requests.Book;
using ServiceModels.Responses.Book;
using WebLibrary.Backend.Provider.Repositories.Interfaces;
using WebLibrary.Commands.Book.Interfaces;
using WebLibrary.Mappers.Book;
using WebLibrary.Validators.Book;

namespace WebLibrary.Commands.Book.Commands;

public class ReadBookCommand : BookActions, IReadBookCommand
{
    public ReadBookCommand(IBookRepository bookRepository, ICreateBookRequestValidator validator, IBookMapper mapper)
        : base(bookRepository, validator, mapper)
    {
    }

    public GetBooksResponse Get()
    {
        List<DbBook> dbBooks = _bookRepository.Get().ToList();

        GetBooksResponse bookResponse = new()
        {
            BookResponses = dbBooks.Select(u => _mapper.Map(u)).ToList()
        };

        return bookResponse;
    }

    public async Task<GetReaderResponse> GetAsync(GetBookRequest request)
    {
        DbBook? book = await _bookRepository.GetAsync(request.Id);

        GetReaderResponse bookResponse = new();

        if (book is null)
        {
            bookResponse.Error = NOT_FOUND;

            return bookResponse;
        }

        return _mapper.Map(book);
    }
}