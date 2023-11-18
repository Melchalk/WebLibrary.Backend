using DbModels;
using FluentValidation.Results;
using Provider.Repositories;
using WebLibrary.Mappers;
using WebLibrary.ModelRequest;
using WebLibrary.ModelsResponses.BookResponses;
using WebLibrary.Validators;

namespace WebLibrary.BooksOptions;

public class BookActions : IBookActions
{
    private const string NOT_FOUND = "ID is not found";
    private const string DELETE = "The deletion was successful";

    private readonly IBookRepository _bookRepository;

    private readonly ICreateBookRequestValidator _validator;
    private readonly IBookMapper _mapper;

    public BookActions(
        IBookRepository bookRepository,
        ICreateBookRequestValidator validator,
        IBookMapper mapper)
    {
        _bookRepository = bookRepository;
        _validator = validator;
        _mapper = mapper;
    }

    public CreateBookResponse Create(BookRequest request)
    {
        CreateBookResponse createResponse = new();

        ValidationResult result = _validator.Validate(request);

        if (!result.IsValid)
        {
            createResponse.Errors = result.Errors.Select(e => e.ErrorMessage).ToList();
        }
        else
        {
            DbBook book = _mapper.Map(request);

            _bookRepository.Add(book);

            createResponse.Id = book.Id;
        }

        return createResponse;
    }

    public GetBookResponse Get(Guid id)
    {
        GetBookResponse getResponse = new();

        DbBook? book = _bookRepository.Get(id);

        if (book is null)
        {
            getResponse.Error = NOT_FOUND;
        }
        else
        {
            getResponse.BookRequest = _mapper.Map(book);
        }

        return getResponse;
    }

    public UpdateBookResponse Update(Guid id, BookRequest request)
    {
        UpdateBookResponse updateResponse = new();

        if (_bookRepository.Get(id) is null)
        {
            updateResponse.Errors = new() { NOT_FOUND };
        }
        else
        {
            ValidationResult result = _validator.Validate(request);

            if (!result.IsValid)
            {
                updateResponse.Errors = result.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                DbBook book = _mapper.Map(request);
                book.Id = id;

                _bookRepository.Update(book);

                updateResponse.Result = true;
            }
        }

        return updateResponse;
    }

    public DeleteBookResponse Delete(Guid id)
    {
        DeleteBookResponse deleteResponse = new();

        DbBook? book = _bookRepository.Get(id);

        if (book is not null)
        {
            _bookRepository.Delete(book);
            deleteResponse.Result = DELETE;
        }
        else
        {
            deleteResponse.Result = NOT_FOUND;
        }

        return deleteResponse;
    }
}
