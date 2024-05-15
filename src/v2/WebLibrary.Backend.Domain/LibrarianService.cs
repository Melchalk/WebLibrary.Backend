using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebLibrary.Backend.Models.Db;
using WebLibrary.Backend.Models.DTO.Requests.Librarian;
using WebLibrary.Backend.Models.DTO.Responses.Librarian;
using WebLibrary.Backend.Models.Exceptions;
using WebLibrary.Backend.Repositories.Interfaces;
using WebLibraryService.Backend.Domain.Interfaces;

namespace WebLibraryService.Backend.Domain;

public class LibrarianService : ILibrarianService
{
    private readonly ILibrarianRepository _repository;
    private readonly ILibraryRepository _libraryRepository;
    private readonly IMapper _mapper;

    public LibrarianService(
        ILibrarianRepository repository,
        ILibraryRepository libraryRepository,
        IMapper mapper)
    {
        _repository = repository;
        _libraryRepository = libraryRepository;
        _mapper = mapper;
    }

    public async Task<Guid> CreateAsync(CreateLibrarianRequest request, CancellationToken token)
    {
        var librarian = _mapper.Map<DbLibrarian>(request);

        await _repository.AddAsync(librarian, token);

        return librarian.Id;
    }

    public async Task<List<GetLibrarianResponse>> GetAllAsync(CancellationToken token)
    {
        return await _mapper.ProjectTo<GetLibrarianResponse>(
            _repository.Get())
            .ToListAsync(token);
    }

    public async Task<GetLibrarianResponse> GetAsync(Guid id, CancellationToken token)
    {
        var librarian = await _repository.GetAsync(id, token)
            ?? throw new BadRequestException($"Librarian with id = '{id}' not found.");

        return _mapper.Map<GetLibrarianResponse>(librarian);
    }

    public async Task DeleteAsync(Guid id, CancellationToken token)
    {
        var librarian = await _repository.GetAsync(id, token)
            ?? throw new BadRequestException($"Librarian with id = '{id}' not found.");

        await _repository.DeleteAsync(librarian, token);
    }

    public async Task UpdateAsync(UpdateLibrarianRequest request, CancellationToken token)
    {
        var librarian = await _repository.GetAsync(request.Id, token)
            ?? throw new BadRequestException($"Librarian with id = '{request.Id}' not found.");

        if (request.LibraryNumber is not null)
        {
            _ = await _libraryRepository.GetAsync((int)request.LibraryNumber, token)
                ?? throw new BadRequestException($"Library with number = '{request.LibraryNumber}' not found.");
        }

        librarian.Phone = request.Phone ?? librarian.Phone;
        librarian.FullName = request.FullName ?? librarian.FullName;
        librarian.LibraryNumber = request.LibraryNumber ?? librarian.LibraryNumber;

        await _repository.SaveAsync(token);
    }
}
