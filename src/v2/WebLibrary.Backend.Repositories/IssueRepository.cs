using DbModels;
using Microsoft.EntityFrameworkCore;
using StructureOfUniversity.PostgreSql.Ef.Interfaces;
using System.Reflection;
using WebLibrary.Backend.Provider.Repositories.Interfaces;

namespace WebLibrary.Backend.Provider.Repositories;

public class IssueRepository : IIssueRepository
{
    private readonly IDataProvider _provider;

    public IssueRepository(IDataProvider provider)
    {
        _provider = provider;
    }

    public async Task AddAsync(DbIssue issue, List<Guid> booksId)
    {
        _provider.Issues.Add(issue);

        foreach (var bookId in booksId)
        {
            (await _provider.Books
                .FirstAsync(u => u.Id == bookId)).IssueId = issue.Id;
        }

        await _provider.SaveAsync();
    }

    public async Task<DbIssue?> GetAsync(Guid issueId)
    {
        return await _provider.Issues
            .Include(u => u.Books)
            .FirstOrDefaultAsync(u => u.Id == issueId);
    }

    public async Task UpdateAsync(DbIssue issue)
    {
        DbIssue? oldIssue = await GetAsync(issue.Id);

        foreach (PropertyInfo property in typeof(DbIssue).GetProperties())
        {
            property?.SetValue(oldIssue, property.GetValue(issue));
        }

        await _provider.SaveAsync();
    }

    public async Task DeleteAsync(DbIssue issue)
    {
        _provider.Issues.Remove(issue);

        await _provider.SaveAsync();
    }
}