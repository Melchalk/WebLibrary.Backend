using DbModels;
using System.ComponentModel.DataAnnotations;

namespace WebLibrary.ModelRequest;

public class ReaderRequest
{
    [MaxLength(50, ErrorMessage = "Fullname is too long")]
    public string Fullname { get; set; }
    [MaxLength(50)]
    public string Telephone { get; set; }
    [MaxLength(50)]
    public string? RegistrationAddress { get; set; }
    public int Age { get; set; }
    public bool CanTakeBooks { get => Age >= 14 && RegistrationAddress is not null; }

    public DbIssue? Issue { get; set; }
}