using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebLibrary.Backend.Models.Db;

public class DbLibrarian
{
    public const string TableName = "Librarians";

    public Guid Id { get; set; }
    public Guid? LibraryId { get; set; }

    [MaxLength(50)]
    public required string FullName { get; set; }

    [MaxLength(50)]
    public required string Phone { get; set; }
    public required string Password { get; set; }
    public required string Salt { get; set; }

    public DbLibrary? Library { get; set; }
}

public class DbLibrarianConfiguration : IEntityTypeConfiguration<DbLibrarian>
{
    public void Configure(EntityTypeBuilder<DbLibrarian> builder)
    {
        builder.HasKey(o => o.Id);

        builder
            .HasOne(u => u.Library)
            .WithMany(o => o.Librarians)
            .HasForeignKey(u => u.LibraryId)
            .HasPrincipalKey(o => o.Id)
            .OnDelete(DeleteBehavior.SetNull);
    }
}