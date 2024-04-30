using DbModels;

namespace Provider.Repositories.Issue;

public interface IIssueRepository : IRepository<DbIssue, Guid>
{
    Task AddAsync(DbIssue issue, List<Guid> booksId);
}