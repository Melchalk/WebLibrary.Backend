using DbModels;

namespace WebLibrary.Backend.Provider.Repositories.Interfaces;

public interface IIssueRepository
{
    Task AddAsync(DbIssue entity, List<Guid> booksId);

    Task<DbIssue?> GetAsync(Guid id);

    Task UpdateAsync(DbIssue entity);

    Task DeleteAsync(DbIssue entity);
}