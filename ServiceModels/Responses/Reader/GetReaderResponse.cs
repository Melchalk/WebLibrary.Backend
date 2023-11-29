using ServiceModels.Responses.Issue;

namespace ServiceModels.Responses.Reader;

public class GetReaderResponse
{
    public string Fullname { get; set; }
    public string Telephone { get; set; }
    public string? RegistrationAddress { get; set; }
    public int Age { get; set; }
    public bool CanTakeBooks { get; set; }

    public string? Error { get; set; }

    public GetIssueResponse? Issue { get; set; }
}