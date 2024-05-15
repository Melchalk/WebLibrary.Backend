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

    public async Task<int> CreateAsync(CreateLibraryRequest request, CancellationToken token)
    {
        var library = _mapper.Map<DbLibrary>(request);

        await _repository.AddAsync(library, token);

        return library.Number;
    }

    public async Task<List<GetLibraryResponse>> GetAllAsync(CancellationToken token)
    {
        return await _mapper.ProjectTo<GetLibraryResponse>(
            _repository.Get())
            .ToListAsync(token);
    }

    public async Task<GetLibraryResponse> GetAsync(int number, CancellationToken token)
    {
        var library = await _repository.GetAsync(number, token)
            ?? throw new BadRequestException($"Library with number = '{number}' not found.");

        return _mapper.Map<GetLibraryResponse>(library);
    }

    public async Task DeleteAsync(int number, CancellationToken token)
    {
        var library = await _repository.GetAsync(number, token)
            ?? throw new BadRequestException($"Library with number = '{number}' not found.");

        await _repository.DeleteAsync(library, token);
    }

    public Task UpdateAsync(UpdateLibraryRequest request, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}
