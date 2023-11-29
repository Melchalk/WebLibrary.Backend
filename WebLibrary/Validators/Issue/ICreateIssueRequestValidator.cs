using FluentValidation;
using ServiceModels.Requests.Issue;

namespace WebLibrary.Validators.Issue;

public interface ICreateIssueRequestValidator : IValidator<CreateIssueRequest>
{
}