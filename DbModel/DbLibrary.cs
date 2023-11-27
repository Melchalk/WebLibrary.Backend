using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DbModels;

public class DbLibrary
{
    public const string TableName = "Libraries";

    public Guid Id { get; set; }

    [MaxLength(50)]
    public string Title { get; set; }

    [MaxLength(50)]
    public string Address { get; set; }

    [MaxLength(50)]
    public string Telephone { get; set; }

    public IList<DbLibrarian> Librarians { get; set; } = new List<DbLibrarian>();
    public IList<DbHall> Halls { get; set; } = new List<DbHall>();

}

public class DbLibraryConfiguration : IEntityTypeConfiguration<DbLibrary>
{
    public void Configure(EntityTypeBuilder<DbLibrary> builder)
    {
        builder.ToTable(DbLibrary.TableName);

        builder.HasKey(o => o.Id);
    }
}