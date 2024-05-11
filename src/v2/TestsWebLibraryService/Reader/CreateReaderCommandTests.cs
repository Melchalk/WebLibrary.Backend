using DbModels;
using FluentValidation.Results;
using Moq;
using ServiceModels.Requests.Reader;
using WebLibrary.Backend.Provider.Repositories.Interfaces;
using WebLibrary.Commands.Reader.Commands;
using WebLibrary.Mappers.Reader;
using WebLibrary.Validators.Reader;

namespace TestsWebLibraryService.Reader;

public class CreateReaderCommandTests
{
    private Mock<ICreateReaderRequestValidator> _createReaderValidatorMock;
    private Mock<IReaderRepository> _readerRepository;
    private Mock<IReaderMapper> _readerMapper;

    private CreateReaderCommand _command;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _createReaderValidatorMock = new Mock<ICreateReaderRequestValidator>();
        _readerRepository = new Mock<IReaderRepository>();
        _readerMapper = new Mock<IReaderMapper>();

        _createReaderValidatorMock
          .Setup(x => x.Validate(It.IsAny<CreateReaderRequest>()))
          .Returns(new ValidationResult());

        _createReaderValidatorMock
          .Setup(x => x.Validate(null))
          .Returns(new ValidationResult()
          {
              Errors = new()
              {
                  new ValidationFailure()
              }
          });

        _readerRepository
             .Setup(x => x.AddAsync(It.IsAny<DbReader>()));

        DbReader _dbReader = new()
        {
            Id = Guid.NewGuid(),
            Fullname = "Test",
            Phone = "Phone",
            RegistrationAddress = "Test",
            Age = 2020,
        };

        _readerMapper
            .Setup(x => x.Map(It.IsAny<CreateReaderRequest>()))
            .Returns(_dbReader);

        _command = new CreateReaderCommand(_readerRepository.Object, _createReaderValidatorMock.Object, _readerMapper.Object);
    }

    [Test]
    public async Task CreateReaderCommandReturnErrorsNullWhenRequestIsOk()
    {
        var request = new CreateReaderRequest
        {
            Fullname = "Charles Dickens",
            Phone = "Phone",
            RegistrationAddress = "Test",
            Age = 2020,
        };

        var actualResult = await _command.CreateAsync(request);

        Assert.That(actualResult.Errors, Is.Null);
    }

    [Test]
    public async Task CreateReaderCommandReturnErrorsEqualsNotNullWhenRequestIsNotOk()
    {
        CreateReaderRequest request = null;

        var actualResult = await _command.CreateAsync(request);

        Assert.That(actualResult.Errors, Is.Not.Null);
    }
}