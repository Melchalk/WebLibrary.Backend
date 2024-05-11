using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DbModels;

public class DbLibrary
{
    public const string TableName = "Libraries";

    public Guid Id { get; set; }

    [MaxLength(50)]
    public required string Title { get; set; }

    [MaxLength(50)]
    public required string Address { get; set; }

    [MaxLength(50)]
    public required string Phone { get; set; }

    public ICollection<DbLibrarian> Librarians { get; set; } = new HashSet<DbLibrarian>();
    public ICollection<DbHall> Halls { get; set; } = new HashSet<DbHall>();
}

public class DbLibraryConfiguration : IEntityTypeConfiguration<DbLibrary>
{
    public void Configure(EntityTypeBuilder<DbLibrary> builder)
    {
        builder.HasKey(o => o.Id);
    }
}