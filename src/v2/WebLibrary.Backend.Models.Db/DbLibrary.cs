using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebLibrary.Backend.Models.Db;

public class DbLibrary
{
    public const string TableName = "Libraries";

    public int Number { get; set; }

    [MaxLength(50)]
    public required string Title { get; set; }

    [MaxLength(50)]
    public required string Address { get; set; }

    [MaxLength(50)]
    public required string Phone { get; set; }
    [MaxLength(50)]
    public required string OwnerPhone { get; set; }

    public ICollection<DbLibrarian> Librarians { get; set; } = new HashSet<DbLibrarian>();
    public ICollection<DbBook> Books { get; set; } = new HashSet<DbBook>();
    public ICollection<DbHall> Halls { get; set; } = new HashSet<DbHall>();
}

public class DbLibraryConfiguration : IEntityTypeConfiguration<DbLibrary>
{
    public void Configure(EntityTypeBuilder<DbLibrary> builder)
    {
        builder.HasKey(o => o.Number);
    }
}