namespace ServiceModels.Responses.Hall;

public class UpdateHallResponse
{
    public bool Result { get; set; }
    public List<string>? Errors { get; set; }
}
