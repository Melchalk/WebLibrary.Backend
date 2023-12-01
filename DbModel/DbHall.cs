using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DbModels;

public class DbHall
{
    public const string TableName = "Halls";

    public Guid LibraryId { get; set; }
    public int No { get; set; }

    [MaxLength(50)]
    public string Title { get; set; }

    [MaxLength(50)]
    public string Thematics { get; set; }

    public DbLibrary Library { get; set; }
}

public class DbHallConfiguration : IEntityTypeConfiguration<DbHall>
{
    public void Configure(EntityTypeBuilder<DbHall> builder)
    {
        builder.ToTable(DbHall.TableName);

        builder.HasKey(o => new { o.LibraryId, o.No });

        builder
            .HasOne(u => u.Library)
            .WithMany(o => o.Halls)
            .HasForeignKey(u => u.LibraryId)
            .HasPrincipalKey(o => o.Id)
            .OnDelete(DeleteBehavior.ClientCascade);
    }
}