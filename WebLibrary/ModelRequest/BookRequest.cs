using DbModels;
using System.ComponentModel.DataAnnotations;

namespace WebLibrary.ModelRequest;

public class BookRequest
{
    [MaxLength(50)]
    public string Title { get; set; }
    [MaxLength(50)]
    public string? Author { get; set; }
    public int NumberPages { get; set; }
    public int YearPublishing { get; set; }
    [MaxLength(50)]
    public string? CityPublishing { get; set; }
    public int? HallNo { get; set; }

    public IList<DbIssueBooks>? IssueBooks { get; set; }
}