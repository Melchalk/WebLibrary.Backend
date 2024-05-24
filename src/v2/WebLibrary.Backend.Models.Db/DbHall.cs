using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebLibrary.Backend.Models.Db;

public class DbHall
{
    public const string TableName = "Halls";

    public int LibraryNumber { get; set; }
    public uint Number { get; set; }

    [MaxLength(50)]
    public string? Title { get; set; }

    [MaxLength(50)]
    public required string Thematic { get; set; }

    public DbLibrary? Library { get; set; }
}

public class DbHallConfiguration : IEntityTypeConfiguration<DbHall>
{
    public void Configure(EntityTypeBuilder<DbHall> builder)
    {
        builder.HasKey(o => new { o.LibraryNumber, o.Number });

        builder
            .HasOne(u => u.Library)
            .WithMany(o => o.Halls)
            .HasForeignKey(u => u.LibraryNumber)
            .HasPrincipalKey(o => o.Number)
            .OnDelete(DeleteBehavior.ClientCascade);
    }
}