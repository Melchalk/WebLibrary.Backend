using DbModels;

namespace WebLibrary.Backend.Provider.Repositories.Interfaces;

public interface IIssueRepository : IRepository<DbIssue, Guid>
{
    Task AddAsync(DbIssue issue, List<Guid> booksId);
}