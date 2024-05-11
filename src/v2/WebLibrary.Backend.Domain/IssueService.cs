using ServiceModels.Requests.Issue;
using ServiceModels.Responses.Issue;
using WebLibraryService.Backend.Domain.Interfaces;

namespace WebLibraryService.Backend.Domain;

public class IssueService : IIssueService
{
    public Task<Guid> CreateAsync(CreateIssueRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<List<GetIssueResponse>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<GetIssueResponse> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(UpdateIssueRequest request)
    {
        throw new NotImplementedException();
    }
}
