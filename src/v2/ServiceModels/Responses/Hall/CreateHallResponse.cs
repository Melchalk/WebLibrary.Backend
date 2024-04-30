namespace ServiceModels.Responses.Hall;

public class CreateHallResponse
{
    public Guid? LibraryId { get; set; }
    public int No { get; set; }

    public List<string>? Errors { get; set; }
}