using ServiceModels.Requests.Book;
using ServiceModels.Requests.Reader;

namespace ServiceModels.Requests.Issue;

public class CreateIssueRequest
{
    public Guid ReaderId { get; set; }
    public DateTime DateIssue { get; set; }
    public int Period { get; set; }

}
