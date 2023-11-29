using DbModels;
using FluentValidation.Results;
using Provider.Repositories.Book;
using ServiceModels.Requests.Book;
using ServiceModels.Responses.Book;
using WebLibrary.Commands.Book.Interfaces;
using WebLibrary.Mappers.Book;
using WebLibrary.Validators;

namespace WebLibrary.Commands.Book.Book_commands;

public class CreaterBook : BookActions, ICreaterBook
{
    public CreaterBook(IBookRepository bookRepository, ICreateBookRequestValidator validator, IBookMapper mapper)
        : base(bookRepository, validator, mapper)
    {
    }

    public async Task<CreateBookResponse> CreateAsync(CreateBookRequest request)
    {
        ValidationResult result = _validator.Validate(request);

        CreateBookResponse bookResponse = new();

        if (!result.IsValid)
        {
            bookResponse.Errors = result.Errors.Select(e => e.ErrorMessage).ToList();

            return bookResponse;
        }

        DbBook book = _mapper.Map(request);

        await _bookRepository.AddAsync(book);

        bookResponse.Id = book.Id;

        return bookResponse;
    }
}
