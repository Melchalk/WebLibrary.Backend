namespace ServiceModels.Responses;

public class GetLibrarianResponse
{
    public string Fullname { get; set; }
    public string Telephone { get; set; }
    public Guid LibraryId { get; set; }
}
