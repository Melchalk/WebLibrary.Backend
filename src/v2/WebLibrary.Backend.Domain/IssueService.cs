using WebLibrary.Backend.Models.DTO.Requests.Issue;
using WebLibrary.Backend.Models.DTO.Responses.Issue;
using WebLibraryService.Backend.Domain.Interfaces;

namespace WebLibraryService.Backend.Domain;

public class IssueService : IIssueService
{
    public Task<Guid> CreateAsync(CreateIssueRequest request, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<List<GetIssueResponse>> GetAllAsync(CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<GetIssueResponse> GetAsync(Guid id, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(UpdateIssueRequest request, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}
