using DbModels;

namespace Provider.Repositories.Issue;

internal interface IIssueRepository : IRepository<DbIssue, Guid>
{
}
