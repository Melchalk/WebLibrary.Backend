using Provider.Repositories.Issue;
using WebLibrary.Mappers.Issue;
using WebLibrary.Validators.Issue;

namespace WebLibrary.Commands.Issue.Commands;

public abstract class IssueActions
{
    protected const string NOT_FOUND = "ID is not found";

    protected readonly IIssueRepository _issueRepository;

    protected readonly ICreateIssueRequestValidator _validator;
    protected readonly IIssueMapper _mapper;

    public IssueActions(
        IIssueRepository issueRepository,
        ICreateIssueRequestValidator validator,
        IIssueMapper mapper)
    {
        _issueRepository = issueRepository;
        _validator = validator;
        _mapper = mapper;
    }
}