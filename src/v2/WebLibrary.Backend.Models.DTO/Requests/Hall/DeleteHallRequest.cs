namespace ServiceModels.Requests.Hall;

public class DeleteHallRequest
{
    public Guid LibraryId { get; set; }
    public int No { get; set; }
}