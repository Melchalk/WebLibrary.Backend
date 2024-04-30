using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DbModels;

public class DbIssue
{
    public const string TableName = "Issues";

    public Guid Id { get; set; }
    public Guid ReaderId { get; set; }
    public DateTime DateIssue { get; set; }
    public int Period { get; set; }

    public IList<DbBook> Books { get; set; } = new List<DbBook>();
    public DbReader Reader { get; set; }
}

public class DbIssueConfiguration : IEntityTypeConfiguration<DbIssue>
{
    public void Configure(EntityTypeBuilder<DbIssue> builder)
    {
        builder.ToTable(DbIssue.TableName);

        builder.HasKey(o => o.Id);

        builder
          .HasOne(o => o.Reader)
          .WithOne(u => u.Issue)
          .OnDelete(DeleteBehavior.ClientCascade);
    }
}