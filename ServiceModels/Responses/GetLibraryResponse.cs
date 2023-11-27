namespace ServiceModels.Responses;

public class GetLibraryResponse
{
    public string Title { get; set; }
    public string Address { get; set; }
    public string Telephone { get; set; }

    public IList<GetLibrarianResponse> Librarians { get; set; } = new List<GetLibrarianResponse>();
    public IList<GetHallResponse> Halls { get; set; } = new List<GetHallResponse>();
}
