using DbModels;
using Microsoft.AspNetCore.Mvc;
using Provider.Repositories;
using WebLibrary.Commands.Book.Interfaces;
using WebLibrary.Mappers.Book;
using WebLibrary.Validators;

namespace WebLibrary.Commands.Book.Book_commands;

public class DeleterBook : BookActions, IDeleterBook
{
    public DeleterBook(IBookRepository bookRepository, ICreateBookRequestValidator validator, IBookMapper mapper)
    : base(bookRepository, validator, mapper)
    {
    }

    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        DbBook? book = await _bookRepository.GetAsync(id);

        if (book is null)
        {
            return new NotFoundObjectResult(NOT_FOUND);
        }

        await _bookRepository.DeleteAsync(book);

        return new OkObjectResult(DELETE);
    }
}
