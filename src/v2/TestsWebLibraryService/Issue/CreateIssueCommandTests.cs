using DbModels;
using FluentValidation.Results;
using Moq;
using Provider.Repositories.Issue;
using ServiceModels.Requests.Issue;
using WebLibrary.Commands.Issue.Commands;
using WebLibrary.Mappers.Issue;
using WebLibrary.Validators.Issue;

namespace TestsWebLibraryService.Issue;

public class CreateIssueCommandTests
{
    private Mock<ICreateIssueRequestValidator> _createIssueValidatorMock;
    private Mock<IIssueRepository> _issueRepository;
    private Mock<IIssueMapper> _issueMapper;

    private CreateIssueCommand _command;

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

        _issueRepository
             .Setup(x => x.AddAsync(It.IsAny<DbIssue>(), It.IsAny<List<Guid>>()));

        DbIssue _dbIssue = new()
        {
            Id = Guid.NewGuid(),
            ReaderId = Guid.NewGuid(),
            DateIssue = DateTime.Today,
            Period = 1,
        };

        _issueMapper
            .Setup(x => x.Map(It.IsAny<CreateIssueRequest>()))
            .Returns(_dbIssue);

        _command = new CreateIssueCommand(_issueRepository.Object, _createIssueValidatorMock.Object, _issueMapper.Object);
    }

    [Test]
    public async Task CreateIssueCommandReturnErrorsNullWhenRequestIsOk()
    {
        var request = new CreateIssueRequest
        {
            ReaderId = Guid.NewGuid(),
            DateIssue = DateTime.Today,
            Period = 1,
        };

        var actualResult = await _command.CreateAsync(request);

        Assert.That(actualResult.Errors, Is.Null);
    }

    [Test]
    public async Task CreateIssueCommandReturnErrorsEqualsNotNullWhenRequestIsNotOk()
    {
        CreateIssueRequest request = null;

        var actualResult = await _command.CreateAsync(request);

        Assert.That(actualResult.Errors, Is.Not.Null);
    }
}