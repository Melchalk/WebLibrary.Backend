using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebLibrary.Backend.Models.Db;
using WebLibrary.Backend.Models.DTO.Requests.Issue;
using WebLibrary.Backend.Models.DTO.Responses.Issue;
using WebLibrary.Backend.Models.Exceptions;
using WebLibrary.Backend.Repositories.Interfaces;
using WebLibraryService.Backend.Domain.Interfaces;

namespace WebLibraryService.Backend.Domain;

public class IssueService : IIssueService
{
    private readonly IIssueRepository _repository;
    private readonly IMapper _mapper;

    public IssueService(
        IIssueRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Guid> CreateAsync(CreateIssueRequest request, CancellationToken token)
    {
        var issue = _mapper.Map<DbIssue>(request);

        await _repository.AddAsync(issue, request.BooksId, token);

        return issue.Id;
    }

    public async Task<List<GetIssueResponse>> GetAllAsync(CancellationToken token)
    {
        return await _mapper.ProjectTo<GetIssueResponse>(
            _repository.Get())
            .ToListAsync(token);
    }

    public async Task<List<GetIssueResponse>> GetByLibraryNumberAsync(int libraryNumber, CancellationToken token)
    {
        var l = await _mapper.ProjectTo<GetIssueResponse>(
            _repository.Get()
            .Where(i => i.Books.First().LibraryNumber == libraryNumber))
            .ToListAsync(token);

        return await _mapper.ProjectTo<GetIssueResponse>(
            _repository.Get()
            .Where(i => i.Books.First().LibraryNumber == libraryNumber))
            .ToListAsync(token);
    }

    public async Task<GetIssueResponse> GetAsync(Guid id, CancellationToken token)
    {
        var issue = await _repository.GetAsync(id, token)
            ?? throw new BadRequestException($"Issue with id = '{id}' not found.");

        return _mapper.Map<GetIssueResponse>(issue);
    }

    public async Task DeleteAsync(Guid id, CancellationToken token)
    {
        var issue = await _repository.GetAsync(id, token)
            ?? throw new BadRequestException($"Issue with id = '{id}' not found.");

        await _repository.DeleteAsync(issue, token);
    }

    public Task UpdateAsync(UpdateIssueRequest request, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}
