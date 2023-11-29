using DbModels;
using FluentValidation.Results;
using Provider.Repositories.Issue;
using ServiceModels.Requests.Issue;
using ServiceModels.Responses.Issue;
using WebLibrary.Commands.Issue.Interfaces;
using WebLibrary.Mappers.Issue;
using WebLibrary.Validators.Issue;

namespace WebLibrary.Commands.Issue.Commands;

public class UpdaterIssue : IssueActions, IUpdaterIssue
{
    public UpdaterIssue(IIssueRepository issueRepository, ICreateIssueRequestValidator validator, IIssueMapper mapper)
    : base(issueRepository, validator, mapper)
    {
    }

    public async Task<UpdateIssueResponse> UpdateAsync(UpdateIssueRequest updateRequest)
    {
        CreateIssueRequest request = updateRequest.CreateIssueRequest;
        Guid id = updateRequest.Id;

        UpdateIssueResponse issueResponse = new();

        if (await _issueRepository.GetAsync(id) is null)
        {
            issueResponse.Errors = new()
            {
                NOT_FOUND
            };

            return issueResponse;
        }

        ValidationResult result = _validator.Validate(request);

        if (!result.IsValid)
        {
            issueResponse.Errors = result.Errors.Select(e => e.ErrorMessage).ToList();

            return issueResponse;
        }

        DbIssue issue = _mapper.Map(request);
        issue.Id = id;

        await _issueRepository.UpdateAsync(issue);

        issueResponse.Result = true;

        return issueResponse;
    }
}