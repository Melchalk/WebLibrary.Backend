using Microsoft.EntityFrameworkCore;
using WebLibrary.Backend.Models.Db;

namespace WebLibrary.Backend.Repositories.Interfaces;

public interface IIssueRepository
{
    Task AddAsync(DbIssue entity, List<Guid> booksId, CancellationToken token);

    Task<DbIssue?> GetAsync(Guid id, CancellationToken token);

    DbSet<DbIssue> Get();

    Task DeleteAsync(DbIssue entity, CancellationToken token);

    Task SaveAsync(CancellationToken token);
}