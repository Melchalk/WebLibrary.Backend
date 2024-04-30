using DbModels;
using FluentValidation.Results;
using Moq;
using Provider.Repositories.Reader;
using ServiceModels.Requests.Reader;
using WebLibrary.Commands.Reader.Commands;
using WebLibrary.Mappers.Reader;
using WebLibrary.Validators.Reader;

namespace TestsWebLibraryService.Reader;

//need to fix
public class UpdateReaderCommandTests
{
    private Mock<ICreateReaderRequestValidator> _createReaderValidatorMock;
    private Mock<IReaderRepository> _readerRepository;
    private Mock<IReaderMapper> _readerMapper;

    private UpdateReaderCommand _command;
    private CreateReaderCommand _commandCreate;

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

        DbReader _dbReader = new()
        {
            Id = Guid.NewGuid(),
            Fullname = "Test",
            Telephone = "Phone",
            RegistrationAddress = "Test",
            Age = 2020,
        };

        _readerRepository
            .Setup(x => x.GetAsync(It.IsAny<Guid>()))
            .ReturnsAsync(_dbReader);

        _readerRepository
            .Setup(x => x.UpdateAsync(It.IsAny<DbReader>()));

        _readerMapper
            .Setup(x => x.Map(It.IsAny<CreateReaderRequest>()))
            .Returns(_dbReader);

        _command = new UpdateReaderCommand(_readerRepository.Object, _createReaderValidatorMock.Object, _readerMapper.Object);
    }

    [Test]
    public async Task UpdateReaderCommandReturnErrorsNullWhenRequestIsOk()
    {
        var requestUpdate = new UpdateReaderRequest
        {
            Id = Guid.NewGuid(),
            CreateReaderRequest = new CreateReaderRequest
            {
                Age = 2023
            }
        };

        var actualResult = await _command.UpdateAsync(requestUpdate);

        Assert.That(actualResult.Errors, Is.Null);
    }
}