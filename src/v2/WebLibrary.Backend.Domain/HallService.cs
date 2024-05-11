using WebLibrary.Backend.Models.DTO.Requests.Hall;
using WebLibrary.Backend.Models.DTO.Responses.Hall;
using WebLibraryService.Backend.Domain.Interfaces;

namespace WebLibraryService.Backend.Domain;

public class HallService : IHallService
{
    public Task<int> CreateAsync(CreateHallRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<List<GetHallResponse>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<GetHallResponse> GetAsync(int number)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int number)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(UpdateHallRequest request)
    {
        throw new NotImplementedException();
    }
}
