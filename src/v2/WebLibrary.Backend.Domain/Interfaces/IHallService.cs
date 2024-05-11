using WebLibrary.Backend.Models.DTO.Requests.Hall;
using WebLibrary.Backend.Models.DTO.Responses.Hall;

namespace WebLibraryService.Backend.Domain.Interfaces;

public interface IHallService
{
    Task<int> CreateAsync(CreateHallRequest request);

    Task<GetHallResponse> GetAsync(int number);

    Task<List<GetHallResponse>> GetAllAsync();

    Task UpdateAsync(UpdateHallRequest request);

    Task DeleteAsync(int number);
}
