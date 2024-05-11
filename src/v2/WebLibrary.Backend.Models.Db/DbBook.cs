using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebLibrary.Backend.Models.Db;

public class DbBook
{
    public const string TableName = "Books";

    public Guid Id { get; set; }
    public uint? HallNo { get; set; }
    public Guid? IssueId { get; set; }

    [MaxLength(50)]
    public required string Title { get; set; }

    [MaxLength(50)]
    public string? Author { get; set; }

    public uint NumberPages { get; set; }
    public uint YearPublishing { get; set; }

    [MaxLength(50)]
    public string? CityPublishing { get; set; }

    public DbIssue? Issue { get; set; }
}

public class DbBookConfiguration : IEntityTypeConfiguration<DbBook>
{
    public void Configure(EntityTypeBuilder<DbBook> builder)
    {
        builder.HasKey(o => o.Id);

        builder
            .HasOne(u => u.Issue)
            .WithMany(o => o.Books)
            .HasForeignKey(u => u.IssueId)
            .HasPrincipalKey(o => o.Id)
            .OnDelete(DeleteBehavior.SetNull);
    }
}