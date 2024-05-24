using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebLibrary.Backend.Models.Db;
using WebLibrary.Backend.Models.DTO.Requests.Hall;
using WebLibrary.Backend.Models.DTO.Responses.Hall;
using WebLibrary.Backend.Models.Exceptions;
using WebLibrary.Backend.Repositories.Interfaces;
using WebLibraryService.Backend.Domain.Interfaces;

namespace WebLibraryService.Backend.Domain;

public class HallService : IHallService
{
    private readonly IHallRepository _repository;
    private readonly IMapper _mapper;

    public HallService(
        IHallRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<uint> CreateAsync(CreateHallRequest request, CancellationToken token)
    {
        var hall = _mapper.Map<DbHall>(request);

        await _repository.AddAsync(hall, token);

        return hall.Number;
    }

    public async Task<List<GetHallResponse>> GetAllAsync(CancellationToken token)
    {
        return await _mapper.ProjectTo<GetHallResponse>(
            _repository.Get())
            .ToListAsync(token);
    }

    public async Task<GetHallResponse> GetAsync(int libraryNumber, uint number, CancellationToken token)
    {
        var hall = await _repository.GetAsync(libraryNumber, number, token)
            ?? throw new BadRequestException($"Hall with library Id = '{libraryNumber}' and number = '{number}' not found.");

        return _mapper.Map<GetHallResponse>(hall);
    }

    public async Task DeleteAsync(int libraryNumber, uint number, CancellationToken token)
    {
        var hall = await _repository.GetAsync(libraryNumber, number, token)
            ?? throw new BadRequestException($"Hall with library Id = '{libraryNumber}' and number = '{number}' not found.");

        await _repository.DeleteAsync(hall, token);
    }

    public Task UpdateAsync(UpdateHallRequest request, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}
