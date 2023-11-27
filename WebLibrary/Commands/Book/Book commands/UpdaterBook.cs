using DbModels;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Provider.Repositories;
using WebLibrary.Commands.Book.Interfaces;
using WebLibrary.Mappers.Book;
using WebLibrary.Requests;
using WebLibrary.Validators;

namespace WebLibrary.Commands.Book.Book_commands;

public class UpdaterBook : BookActions, IUpdaterBook
{
    public UpdaterBook(IBookRepository bookRepository, ICreateBookRequestValidator validator, IBookMapper mapper)
    : base(bookRepository, validator, mapper)
    {
    }

    public async Task<IActionResult> UpdateAsync(Guid id, CreateBookRequest request)
    {
        if (await _bookRepository.GetAsync(id) is null)
        {
            return new NotFoundObjectResult(NOT_FOUND);
        }

        ValidationResult result = _validator.Validate(request);

        if (!result.IsValid)
        {
            List<string> errors = result.Errors.Select(e => e.ErrorMessage).ToList();

            return new BadRequestObjectResult(errors);
        }

        DbBook book = _mapper.Map(request);
        book.Id = id;

        await _bookRepository.UpdateAsync(book);

        return new OkResult();
    }
}
