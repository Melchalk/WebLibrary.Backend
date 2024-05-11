using ServiceModels.Requests.Issue;
using ServiceModels.Responses.Issue;

namespace WebLibraryService.Backend.Domain.Interfaces;

public interface IIssueService
{
    Task<Guid> CreateAsync(CreateIssueRequest request);

    Task<GetIssueResponse> GetAsync(Guid id);

    Task<List<GetIssueResponse>> GetAllAsync();

    Task UpdateAsync(UpdateIssueRequest request);

    Task DeleteAsync(Guid id);
}
