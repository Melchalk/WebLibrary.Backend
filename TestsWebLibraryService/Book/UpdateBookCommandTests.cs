using DbModels;
using FluentValidation.Results;
using Moq;
using Provider.Repositories.Book;
using ServiceModels.Requests.Book;
using WebLibrary.Commands.Book.Commands;
using WebLibrary.Mappers.Book;
using WebLibrary.Validators.Book;

namespace TestsWebLibraryService.Book;

//need to fix
public class UpdateBookCommandTests
{
    private Mock<ICreateBookRequestValidator> _createBookValidatorMock;
    private Mock<IBookRepository> _bookRepository;
    private Mock<IBookMapper> _bookMapper;

    private UpdateBookCommand _command;
    private CreateBookCommand _commandCreate;

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

        DbBook _dbBook = new()
        {
            Id = Guid.NewGuid(),
            Title = "Test",
            NumberPages = 1,
            YearPublishing = 1,
        };

        _bookRepository
            .Setup(x => x.GetAsync(It.IsAny<Guid>()))
            .ReturnsAsync(_dbBook);

        _bookRepository
            .Setup(x => x.UpdateAsync(It.IsAny<DbBook>()));

        _bookMapper
            .Setup(x => x.Map(It.IsAny<CreateBookRequest>()))
            .Returns(_dbBook);

        _command = new UpdateBookCommand(_bookRepository.Object, _createBookValidatorMock.Object, _bookMapper.Object);
        _commandCreate = new CreateBookCommand(_bookRepository.Object, _createBookValidatorMock.Object, _bookMapper.Object);
    }

    [Test]
    public async Task UpdateBookCommandReturnErrorsNullWhenRequestIsOk()
    {
        var requestUpdate = new UpdateBookRequest
        {
            Id = Guid.NewGuid(),
            CreateBookRequest = new CreateBookRequest
            {
                YearPublishing = 2023
            }
        };

        var actualResult = await _command.UpdateAsync(requestUpdate);

        Assert.That(actualResult.Errors, Is.Null);
    }

    [Test]
    public async Task UpdateBookCommandReturnErrorsEqualsNotNullWhenRequestIsNotOk()
    {
        UpdateBookRequest request = null;

        var actualResult = await _command.UpdateAsync(request);

        Assert.That(actualResult.Errors, Is.Not.Null);
    }
}