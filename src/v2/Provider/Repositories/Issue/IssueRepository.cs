using DbModels;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Provider.Repositories.Issue;

public class IssueRepository : IIssueRepository
{
    private readonly OfficeDbContext _context = new();

    public async Task AddAsync(DbIssue issue, List<Guid> booksId)
    {
        _context.Issues.Add(issue);

        foreach (var bookId in booksId)
        {
            (await _context.Books
                .FirstAsync(u => u.Id == bookId)).IssueId = issue.Id;
        }

        await _context.SaveChangesAsync();
    }

    public async Task<DbIssue?> GetAsync(Guid issueId)
    {
        return await _context.Issues
            .Include(u => u.Books)
            .FirstOrDefaultAsync(u => u.Id == issueId);
    }

    public DbSet<DbIssue> Get()
    {
        return _context.Issues;
    }

    public async Task<DbIssue?> UpdateAsync(DbIssue? issue)
    {
        DbIssue? oldIssue = await GetAsync(issue.Id);

        if (oldIssue is null)
        {
            return null;
        }

        foreach (PropertyInfo property in typeof(DbIssue).GetProperties())
        {
            property?.SetValue(oldIssue, property.GetValue(issue));
        }

        await _context.SaveChangesAsync();

        return await GetAsync(issue.Id);
    }

    public async Task DeleteAsync(DbIssue issue)
    {
        _context.Issues.Remove(issue);

        await _context.SaveChangesAsync();
    }
}