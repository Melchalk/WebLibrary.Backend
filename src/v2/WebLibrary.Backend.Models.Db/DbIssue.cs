using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace WebLibrary.Backend.Models.Db;

public class DbIssue
{
    public const string TableName = "Issues";

    public Guid Id { get; set; }
    public Guid ReaderId { get; set; }
    public DateTime ReturnDate { get; set; }

    public DbReader? Reader { get; set; }
    public ICollection<DbBook> Books { get; set; } = new HashSet<DbBook>();
}

public class DbIssueConfiguration : IEntityTypeConfiguration<DbIssue>
{
    public void Configure(EntityTypeBuilder<DbIssue> builder)
    {
        builder.HasKey(o => o.Id);

        builder
          .HasOne(o => o.Reader)
          .WithOne(u => u.Issue)
          .OnDelete(DeleteBehavior.ClientCascade);
    }
}