using Microsoft.EntityFrameworkCore;
using WebLibrary.Backend.Models.Db;

namespace WebLibrary.Backend.Repositories.Interfaces;

public interface IIssueRepository
{
    Task AddAsync(DbIssue entity, List<Guid> booksId);

    Task<DbIssue?> GetAsync(Guid id);

    DbSet<DbIssue> Get();

    Task UpdateAsync(DbIssue entity);

    Task DeleteAsync(DbIssue entity);
}