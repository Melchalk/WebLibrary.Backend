using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebLibrary.Backend.Models.Db;

public class DbReader
{
    public const string TableName = "Readers";

    public Guid Id { get; set; }

    [MaxLength(50)]
    public required string FullName { get; set; }

    [MaxLength(50)]
    public required string Phone { get; set; }

    [MaxLength(50)]
    public string? RegistrationAddress { get; set; }

    public uint Age { get; set; }
    public bool CanTakeBooks { get; set; }

    public DbIssue? Issue { get; set; }
}

public class DbReaderConfiguration : IEntityTypeConfiguration<DbReader>
{
    public void Configure(EntityTypeBuilder<DbReader> builder)
    {
        builder.HasKey(o => o.Id);
    }
}