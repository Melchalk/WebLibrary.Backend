using DbModels;
using ServiceModels.Requests.Issue;
using ServiceModels.Responses.Issue;
using WebLibrary.Backend.Provider.Repositories.Interfaces;
using WebLibrary.Commands.Issue.Interfaces;
using WebLibrary.Mappers.Issue;
using WebLibrary.Validators.Issue;

namespace WebLibrary.Commands.Issue.Commands;

public class DeleteIssueCommand : IssueActions, IDeleteIssueCommand
{
    public DeleteIssueCommand(IIssueRepository issueRepository, ICreateIssueRequestValidator validator, IIssueMapper mapper)
        : base(issueRepository, validator, mapper)
    {
    }

    public async Task<DeleteIssueResponse> DeleteAsync(DeleteIssueRequest request)
    {
        DeleteIssueResponse issueResponse = new();

        Guid id = request.Id;

        DbIssue? issue = await _issueRepository.GetAsync(id);

        if (issue is null)
        {
            issueResponse.Error = NOT_FOUND;

            return issueResponse;
        }

        await _issueRepository.DeleteAsync(issue);

        issueResponse.Result = true;

        return issueResponse;
    }
}