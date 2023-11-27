using DbModels;
using Microsoft.AspNetCore.Mvc;
using Provider.Repositories.Book;
using WebLibrary.Commands.Book.Interfaces;
using WebLibrary.Mappers.Book;
using WebLibrary.Responses;
using WebLibrary.Validators;

namespace WebLibrary.Commands.Book.Book_commands;

public class ReaderBook : BookActions, IReaderBook
{
    public ReaderBook(IBookRepository bookRepository, ICreateBookRequestValidator validator, IBookMapper mapper)
    : base(bookRepository, validator, mapper)
    {
    }

    public IActionResult Get()
    {
        List<DbBook> dbBooks = _bookRepository.Get().ToList();

        List<GetBookResponse> bookResponse = dbBooks.Select(u => _mapper.Map(u)).ToList();

        return new OkObjectResult(bookResponse);
    }

    public async Task<IActionResult> GetAsync(Guid id)
    {
        DbBook? book = await _bookRepository.GetAsync(id);

        if (book is null)
        {
            return new NotFoundObjectResult(NOT_FOUND);
        }

        return new OkObjectResult(_mapper.Map(book));
    }
}
