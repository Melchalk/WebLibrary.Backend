namespace WebLibrary.ModelsResponses.BookResponses;

public class CreateBookResponse
{
    public Guid? Id { get; set; }
    public List<string>? Errors { get; set; }
}
