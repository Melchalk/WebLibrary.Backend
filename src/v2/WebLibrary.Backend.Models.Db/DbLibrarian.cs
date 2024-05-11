using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DbModels;

public class DbLibrarian
{
    public const string TableName = "Librarians";

    public Guid Id { get; set; }

    [MaxLength(50)]
    public string Fullname { get; set; }

    [MaxLength(50)]
    public string Telephone { get; set; }

    public Guid? LibraryId { get; set; }

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