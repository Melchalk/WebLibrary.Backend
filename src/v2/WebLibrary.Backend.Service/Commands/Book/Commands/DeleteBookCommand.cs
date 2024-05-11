using ServiceModels.Requests.Book;
using ServiceModels.Responses.Book;
using WebLibrary.Backend.Models.Db;
using WebLibrary.Backend.Provider.Repositories.Interfaces;
using WebLibrary.Commands.Book.Interfaces;
using WebLibrary.Mappers.Book;
using WebLibrary.Validators.Book;

namespace WebLibrary.Commands.Book.Commands;

public class DeleteBookCommand : BookActions, IDeleteBookCommand
{
    public DeleteBookCommand(IBookRepository bookRepository, ICreateBookRequestValidator validator, IBookMapper mapper)
        : base(bookRepository, validator, mapper)
    {
    }

    public async Task<DeleteBookResponse> DeleteAsync(DeleteBookRequest request)
    {
        DeleteBookResponse bookResponse = new();

        Guid id = request.Id;

        DbBook? book = await _bookRepository.GetAsync(id);

        if (book is null)
        {
            bookResponse.Error = NOT_FOUND;

            return bookResponse;
        }

        await _bookRepository.DeleteAsync(book);

        bookResponse.Result = true;

        return bookResponse;
    }
}