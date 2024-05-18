using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WebLibrary.Backend.Extensions;
using WebLibrary.Backend.Models.Db;
using WebLibrary.Backend.Models.DTO.Requests.Library;
using WebLibrary.Backend.Models.DTO.Responses.Library;
using WebLibrary.Backend.Models.Exceptions;
using WebLibrary.Backend.Repositories.Interfaces;
using WebLibraryService.Backend.Domain.Interfaces;

namespace WebLibraryService.Backend.Domain;

public class LibraryService : ILibraryService
{
    private readonly IHttpContextAccessor _httpContext;

    private readonly ILibraryRepository _repository;
    private readonly ILibrarianRepository _librarianRepository;
    private readonly IMapper _mapper;

    public LibraryService(
        IHttpContextAccessor httpContext,
        ILibraryRepository repository,
        ILibrarianRepository librarianRepository,
        IMapper mapper)
    {
        _httpContext = httpContext;
        _librarianRepository = librarianRepository;
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<int> CreateAsync(CreateLibraryRequest request, CancellationToken token)
    {
        var ownerPhone = _httpContext.GetUserPhone();

        var library = _mapper.Map<DbLibrary>(request);
        library.OwnerPhone = ownerPhone;

        await _repository.AddAsync(library, token);

        var owner = await _librarianRepository.Get().FirstAsync(u => u.Phone == ownerPhone, token);

        owner.LibraryNumber = library.Number;
        await _librarianRepository.SaveAsync(token);

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

        var response = _mapper.Map<GetLibraryResponse>(library);
        response.OwnerName = (await _librarianRepository.Get()
            .FirstAsync(l => l.Phone == library.OwnerPhone))
            .FullName;

        return response;
    }

    public async Task DeleteAsync(int number, CancellationToken token)
    {
        var library = await _repository.GetAsync(number, token)
            ?? throw new BadRequestException($"Library with number = '{number}' not found.");

        await _repository.DeleteAsync(library, token);
    }

    public async Task UpdateAsync(UpdateLibraryRequest request, CancellationToken token)
    {
        var library = await _repository.GetAsync(request.Number, token)
            ?? throw new BadRequestException($"Library with number = '{request.Number}' not found.");

        library.Title = request.Title ?? library.Title;
        library.Address = request.Address ?? library.Address;
        library.Phone = request.Phone ?? library.Phone;

        await _repository.SaveAsync(token);
    }
}
