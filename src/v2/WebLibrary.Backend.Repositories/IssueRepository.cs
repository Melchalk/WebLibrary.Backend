using Microsoft.EntityFrameworkCore;
using WebLibrary.Backend.Models.Db;
using WebLibrary.Backend.Provider.Interfaces;
using WebLibrary.Backend.Repositories.Interfaces;

namespace WebLibrary.Backend.Repositories;

public class IssueRepository : IIssueRepository
{
    private readonly IDataProvider _provider;

    public IssueRepository(IDataProvider provider)
    {
        _provider = provider;
    }

    public async Task AddAsync(
        DbIssue issue,
        List<Guid> booksId,
        CancellationToken token)
    {
        await _provider.Issues.AddAsync(issue, token);
        await _provider.SaveAsync(token);

        foreach (var bookId in booksId)
        {
            (await _provider.Books
                .FirstAsync(u => u.Id == bookId, token)).IssueId = issue.Id;

            await _provider.SaveAsync(token);
        }
    }

    public async Task<DbIssue?> GetAsync(Guid issueId, CancellationToken token)
    {
        return await _provider.Issues
            .Include(u => u.Books)
            .FirstOrDefaultAsync(u => u.Id == issueId, token);
    }

    public async Task DeleteAsync(DbIssue issue, CancellationToken token)
    {
        _provider.Issues.Remove(issue);

        await _provider.SaveAsync(token);
    }

    public DbSet<DbIssue> Get() => _provider.Issues;

    public async Task SaveAsync(CancellationToken token) => await _provider.SaveAsync(token);
}