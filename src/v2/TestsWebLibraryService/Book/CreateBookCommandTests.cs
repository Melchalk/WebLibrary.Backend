using DbModels;
using FluentValidation.Results;
using Moq;
using ServiceModels.Requests.Book;
using WebLibrary.Backend.Provider.Repositories.Interfaces;
using WebLibrary.Commands.Book.Commands;
using WebLibrary.Mappers.Book;
using WebLibrary.Validators.Book;

namespace TestsWebLibraryService.Book;

public class CreateBookCommandTests
{
    private Mock<ICreateBookRequestValidator> _createBookValidatorMock;
    private Mock<IBookRepository> _bookRepository;
    private Mock<IBookMapper> _bookMapper;

    private CreateBookCommand _command;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _createBookValidatorMock = new Mock<ICreateBookRequestValidator>();
        _bookRepository = new Mock<IBookRepository>();
        _bookMapper = new Mock<IBookMapper>();

        _createBookValidatorMock
          .Setup(x => x.Validate(It.IsAny<CreateBookRequest>()))
          .Returns(new ValidationResult());

        _createBookValidatorMock
          .Setup(x => x.Validate(null))
          .Returns(new ValidationResult()
          {
              Errors = new()
              {
                  new ValidationFailure()
              }
          });

        _bookRepository
             .Setup(x => x.AddAsync(It.IsAny<DbBook>()));

        DbBook _dbBook = new()
        {
            Id = Guid.NewGuid(),
            Title = "Test",
            NumberPages = 1,
            YearPublishing = 1,
        };

        _bookMapper
            .Setup(x => x.Map(It.IsAny<CreateBookRequest>()))
            .Returns(_dbBook);

        _command = new CreateBookCommand(_bookRepository.Object, _createBookValidatorMock.Object, _bookMapper.Object);
    }

    [Test]
    public async Task CreateBookCommandReturnErrorsNullWhenRequestIsOk()
    {
        var request = new CreateBookRequest
        {
            Title = "Great Expectations",
            Author = "Charles Dickens",
            NumberPages = 250,
            YearPublishing = 2020
        };

        var actualResult = await _command.CreateAsync(request);

        Assert.That(actualResult.Errors, Is.Null);
    }

    [Test]
    public async Task CreateBookCommandReturnErrorsEqualsNotNullWhenRequestIsNotOk()
    {
        CreateBookRequest request = null;

        var actualResult = await _command.CreateAsync(request);

        Assert.That(actualResult.Errors, Is.Not.Null);
    }
}