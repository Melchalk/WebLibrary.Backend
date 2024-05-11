using DbModels;
using FluentValidation.Results;
using ServiceModels.Requests.Issue;
using ServiceModels.Responses.Issue;
using WebLibrary.Backend.Provider.Repositories.Interfaces;
using WebLibrary.Commands.Issue.Interfaces;
using WebLibrary.Mappers.Issue;
using WebLibrary.Validators.Issue;

namespace WebLibrary.Commands.Issue.Commands;

public class CreateIssueCommand : IssueActions, ICreateIssueCommand
{
    public CreateIssueCommand(IIssueRepository issueRepository, ICreateIssueRequestValidator validator, IIssueMapper mapper)
        : base(issueRepository, validator, mapper)
    {
    }

    public async Task<CreateIssueResponse> CreateAsync(CreateIssueRequest request)
    {
        ValidationResult result = _validator.Validate(request);

        CreateIssueResponse issueResponse = new();

        if (!result.IsValid)
        {
            issueResponse.Errors = result.Errors.Select(e => e.ErrorMessage).ToList();

            return issueResponse;
        }

        DbIssue issue = _mapper.Map(request);

        await _issueRepository.AddAsync(issue, request.BooksId);

        issueResponse.Id = issue.Id;

        return issueResponse;
    }
}