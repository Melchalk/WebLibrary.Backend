using FluentValidation;
using ServiceModels.Requests.Issue;
using WebLibrary.Validators.Issue;

namespace WebLibrary.Validators.Book;

public class CreateIssueRequestValidator : AbstractValidator<CreateIssueRequest>, ICreateIssueRequestValidator
{
    public CreateIssueRequestValidator()
    {

    }
}