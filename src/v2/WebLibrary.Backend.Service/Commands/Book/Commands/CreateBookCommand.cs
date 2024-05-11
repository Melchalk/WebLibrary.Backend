using FluentValidation.Results;
using ServiceModels.Responses.Book;
using WebLibrary.Backend.Models.Db;
using WebLibrary.Backend.Models.DTO.Requests.Book;
using WebLibrary.Backend.Provider.Repositories.Interfaces;
using WebLibrary.Commands.Book.Interfaces;
using WebLibrary.Mappers.Book;
using WebLibrary.Validators.Book;

namespace WebLibrary.Commands.Book.Commands;

public class CreateBookCommand : BookActions, ICreateBookCommand
{
    public CreateBookCommand(IBookRepository bookRepository, ICreateBookRequestValidator validator, IBookMapper mapper)
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