using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbModels;

public class DbIssueBooks
{
    public const string TableName = "IssueBooks";

    public Guid IssueId { get; set; }
    public Guid BookId { get; set; }

    public DbBook Book { get; set; }
    public DbIssue Issue { get; set; }
}

public class DbIssueBooksConfiguration : IEntityTypeConfiguration<DbIssueBooks>
{
    public void Configure(EntityTypeBuilder<DbIssueBooks> builder)
    {
        builder.ToTable(DbIssueBooks.TableName);

        builder.HasKey(u => new { u.IssueId, u.BookId });

        builder
            .HasOne(u => u.Issue)
            .WithMany(o => o.IssueBooks)
            .HasForeignKey(u => u.IssueId)
            .HasPrincipalKey(o => o.Id);

        builder
            .HasOne(u => u.Book)
            .WithMany(o => o.IssueBooks)
            .HasForeignKey(u => u.BookId)
            .HasPrincipalKey(o => o.Id);
    }
}