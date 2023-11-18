using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DbModels;

public class DbBook
{
    public const string TableName = "Books";

    public Guid Id { get; set; }
    [MaxLength(50)]
    public string Title { get; set; }
    [MaxLength(50)]
    public string? Author { get; set; }
    public int NumberPages { get; set; }
    public int YearPublishing { get; set; }
    [MaxLength(50)]
    public string? CityPublishing { get; set; }
    public int? HallNo { get; set; }

    public IList<DbIssueBooks> IssueBooks { get; set; } = new List<DbIssueBooks>();
}

public class DbBookConfiguration : IEntityTypeConfiguration<DbBook>
{
    public void Configure(EntityTypeBuilder<DbBook> builder)
    {
        builder.ToTable(DbBook.TableName);

        builder.HasKey(o => o.Id);
    }
}