using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebLibrary.Backend.Models.Db;
using WebLibrary.Backend.Models.DTO.Requests.Library;
using WebLibrary.Backend.Models.DTO.Responses.Library;
using WebLibrary.Backend.Models.Exceptions;
using WebLibrary.Backend.Repositories.Interfaces;
using WebLibraryService.Backend.Domain.Interfaces;

namespace WebLibraryService.Backend.Domain;

public class LibraryService : ILibraryService
{
    private readonly ILibraryRepository _repository;
    private readonly IMapper _mapper;

    public LibraryService(
        ILibraryRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Guid> CreateAsync(CreateLibraryRequest request, CancellationToken token)
    {
        var library = _mapper.Map<DbLibrary>(request);

        await _repository.AddAsync(library, token);

        return library.Id;
    }

    public async Task<List<GetLibraryResponse>> GetAllAsync(CancellationToken token)
    {
        return await _mapper.ProjectTo<GetLibraryResponse>(
            _repository.Get())
            .ToListAsync(token);
    }

    public async Task<GetLibraryResponse> GetAsync(Guid id, CancellationToken token)
    {
        var library = await _repository.GetAsync(id, token)
            ?? throw new BadRequestException($"Library with id = '{id}' not found.");

        return _mapper.Map<GetLibraryResponse>(library);
    }

    public async Task DeleteAsync(Guid id, CancellationToken token)
    {
        var library = await _repository.GetAsync(id, token)
            ?? throw new BadRequestException($"Library with id = '{id}' not found.");

        await _repository.DeleteAsync(library, token);
    }

    public Task UpdateAsync(UpdateLibraryRequest request, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}
