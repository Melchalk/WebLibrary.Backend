using ServiceModels.Requests.Issue;
using WebLibrary.Backend.Models.Db;
using WebLibrary.Backend.Models.DTO.Responses.Issue;
using WebLibrary.Backend.Provider.Repositories.Interfaces;
using WebLibrary.Commands.Issue.Interfaces;
using WebLibrary.Mappers.Issue;
using WebLibrary.Validators.Issue;

namespace WebLibrary.Commands.Issue.Commands;

public class ReadIssueCommand : IssueActions, IReadIssueCommand
{
    public ReadIssueCommand(IIssueRepository issueRepository, ICreateIssueRequestValidator validator, IIssueMapper mapper)
        : base(issueRepository, validator, mapper)
    {
    }

    public GetIssuesResponse Get()
    {
        List<DbIssue> dbIssues = _issueRepository.Get().ToList();

        GetIssuesResponse issueResponse = new()
        {
            IssueResponses = dbIssues.Select(u => _mapper.Map(u)).ToList()
        };

        return issueResponse;
    }

    public async Task<GetIssueResponse> GetAsync(GetIssueRequest request)
    {
        DbIssue? issue = await _issueRepository.GetAsync(request.Id);

        GetIssueResponse issueResponse = new();

        if (issue is null)
        {
            issueResponse.Error = NOT_FOUND;

            return issueResponse;
        }

        return _mapper.Map(issue);
    }
}