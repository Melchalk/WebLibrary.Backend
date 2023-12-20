namespace ServiceModels.Responses.Book;

public class UpdateBookResponse
{
    public bool Result { get; set; }
    public List<string>? Errors { get; set; }
}