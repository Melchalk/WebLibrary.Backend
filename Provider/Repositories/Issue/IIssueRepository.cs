using DbModels;

namespace Provider.Repositories.Issue;

public interface IIssueRepository : IRepository<DbIssue, Guid>
{
}
