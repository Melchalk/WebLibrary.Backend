using System.ComponentModel.DataAnnotations;

namespace ServiceModels.Requests.Reader;

public class CreateReaderRequest
{
    [MaxLength(50, ErrorMessage = "FullName is too long")]
    public required string FullName { get; set; }

    [MaxLength(50, ErrorMessage = "Telephone is too long")]
    public required string Telephone { get; set; }

    [MaxLength(50, ErrorMessage = "Registration address is too long")]
    public string? RegistrationAddress { get; set; }

    [Range(14, 100, ErrorMessage = "The age must be over 14")]
    public int Age { get; set; }
    public bool CanTakeBooks { get => Age >= 18 && RegistrationAddress != null; }
}