using WebLibrary.Backend.Models.Db;

namespace WebLibrary.Backend.Repositories.Interfaces;

public interface IIssueRepository
{
    Task AddAsync(DbIssue entity, List<Guid> booksId);

    Task<DbIssue?> GetAsync(Guid id);

    Task UpdateAsync(DbIssue entity);

    Task DeleteAsync(DbIssue entity);
}