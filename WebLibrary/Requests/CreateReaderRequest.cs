using System.ComponentModel.DataAnnotations;

namespace WebLibrary.Requests;

public class CreateReaderRequest
{
    [MaxLength(50, ErrorMessage = "Fullname is too long")]
    public string Fullname { get; set; }

    [MaxLength(50, ErrorMessage = "Telephone is too long")]
    public string Telephone { get; set; }

    [MaxLength(50, ErrorMessage = "Registration address is too long")]
    public string? RegistrationAddress { get; set; }

    public int Age { get; set; }
    public bool CanTakeBooks { get => Age >= 18 && RegistrationAddress != null; }
}