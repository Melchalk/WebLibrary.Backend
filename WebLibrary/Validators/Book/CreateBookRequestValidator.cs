using FluentValidation;
using ServiceModels.Requests.Issue;

namespace WebLibrary.Validators.Issue;

public class CreateIssueRequestValidator : AbstractValidator<CreateIssueRequest>, ICreateIssueRequestValidator
{
    public CreateIssueRequestValidator()
    {

    }
}