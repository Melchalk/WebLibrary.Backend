using DbModels;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Provider.Repositories.Book;
using WebLibrary.Commands.Book.Interfaces;
using WebLibrary.Mappers.Book;
using WebLibrary.Requests;
using WebLibrary.Validators;

namespace WebLibrary.Commands.Book.Book_commands;

public class CreaterBook : BookActions, ICreaterBook
{
    public CreaterBook(IBookRepository bookRepository, ICreateBookRequestValidator validator, IBookMapper mapper)
        : base(bookRepository, validator, mapper)
    {
    }

    public async Task<IActionResult> CreateAsync(CreateBookRequest request)
    {
        ValidationResult result = _validator.Validate(request);

        if (!result.IsValid)
        {
            List<string> errors = result.Errors.Select(e => e.ErrorMessage).ToList();

            return new BadRequestObjectResult(errors);
        }

        DbBook book = _mapper.Map(request);

        await _bookRepository.AddAsync(book);

        return new CreatedResult("Library.Books", book.Id);
    }
}
