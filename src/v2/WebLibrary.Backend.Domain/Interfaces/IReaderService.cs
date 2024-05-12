using WebLibrary.Backend.Models.DTO.Requests.Reader;
using WebLibrary.Backend.Models.DTO.Responses.Reader;

namespace WebLibraryService.Backend.Domain.Interfaces;

public interface IReaderService
{
    Task<Guid> CreateAsync(CreateReaderRequest request, CancellationToken token);

    Task<GetReaderResponse> GetAsync(Guid id, CancellationToken token);

    Task<List<GetReaderResponse>> GetAllAsync(CancellationToken token);

    Task UpdateAsync(UpdateReaderRequest request, CancellationToken token);

    Task DeleteAsync(Guid id, CancellationToken token);
}
