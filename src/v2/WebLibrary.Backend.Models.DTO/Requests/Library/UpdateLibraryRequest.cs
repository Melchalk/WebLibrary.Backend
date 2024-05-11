using System.ComponentModel.DataAnnotations;

namespace ServiceModels.Requests.Library;

public class UpdateLibraryRequest
{
    public Guid Id { get; set; }

    [MaxLength(50)]
    public string? Title { get; set; }

    [MaxLength(50)]
    public string? Address { get; set; }

    [MaxLength(50)]
    public string? Phone { get; set; }
}