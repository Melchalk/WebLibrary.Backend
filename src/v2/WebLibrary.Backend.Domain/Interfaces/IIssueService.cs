using WebLibrary.Backend.Models.DTO.Requests.Issue;
using WebLibrary.Backend.Models.DTO.Responses.Issue;

namespace WebLibraryService.Backend.Domain.Interfaces;

public interface IIssueService
{
    Task<Guid> CreateAsync(CreateIssueRequest request, CancellationToken token);

    Task<GetIssueResponse> GetAsync(Guid id, CancellationToken token);

    Task<List<GetIssueResponse>> GetAllAsync(CancellationToken token);

    Task<List<GetIssueResponse>> GetByLibraryNumberAsync(int libraryNumber, CancellationToken token);

    Task UpdateAsync(UpdateIssueRequest request, CancellationToken token);

    Task DeleteAsync(Guid id, CancellationToken token);
}
