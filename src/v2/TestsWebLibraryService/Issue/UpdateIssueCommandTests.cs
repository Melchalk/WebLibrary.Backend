using FluentValidation.Results;
using Moq;
using ServiceModels.Requests.Issue;
using WebLibrary.Backend.Models.Db;
using WebLibrary.Backend.Models.DTO.Requests.Issue;
using WebLibrary.Backend.Provider.Repositories.Interfaces;
using WebLibrary.Commands.Issue.Commands;
using WebLibrary.Mappers.Issue;
using WebLibrary.Validators.Issue;

namespace TestsWebLibraryService.Issue;

public class UpdateIssueCommandTests
{
    private Mock<ICreateIssueRequestValidator> _createIssueValidatorMock;
    private Mock<IIssueRepository> _issueRepository;
    private Mock<IIssueMapper> _issueMapper;

    private UpdateIssueCommand _command;
    private CreateIssueCommand _commandCreate;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _createIssueValidatorMock = new Mock<ICreateIssueRequestValidator>();
        _issueRepository = new Mock<IIssueRepository>();
        _issueMapper = new Mock<IIssueMapper>();

        _createIssueValidatorMock
            .Setup(x => x.Validate(It.IsAny<CreateIssueRequest>()))
            .Returns(new ValidationResult());

        _createIssueValidatorMock
            .Setup(x => x.Validate(null))
            .Returns(new ValidationResult()
            {
                Errors = new()
              {
                new ValidationFailure()
              }
            });

        DbIssue _dbIssue = new()
        {
            Id = Guid.NewGuid(),
            ReaderId = Guid.NewGuid(),
            DateIssue = DateTime.Today,
            Period = 1,
        };

        _issueRepository
            .Setup(x => x.GetAsync(It.IsAny<Guid>()))
            .ReturnsAsync(_dbIssue);

        _issueRepository
            .Setup(x => x.UpdateAsync(It.IsAny<DbIssue>()));

        _issueMapper
            .Setup(x => x.Map(It.IsAny<CreateIssueRequest>()))
            .Returns(_dbIssue);

        _command = new UpdateIssueCommand(_issueRepository.Object, _createIssueValidatorMock.Object, _issueMapper.Object);
    }

    [Test]
    public async Task UpdateIssueCommandReturnErrorsNullWhenRequestIsOk()
    {
        var requestUpdate = new UpdateIssueRequest
        {
            Id = Guid.NewGuid(),
            CreateIssueRequest = new CreateIssueRequest
            {
                Period = 20
            }
        };

        var actualResult = await _command.UpdateAsync(requestUpdate);

        Assert.That(actualResult.Errors, Is.Null);
    }
}