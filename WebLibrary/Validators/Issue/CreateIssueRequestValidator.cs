using FluentValidation;
using ServiceModels.Requests.Book;

namespace WebLibrary.Validators.Book;

public class CreateIssueRequestValidator : AbstractValidator<CreateBookRequest>, ICreateBookRequestValidator
{
    public CreateIssueRequestValidator()
    {
        RuleFor(request => request.Title)
          .NotEmpty();

        RuleFor(request => request.NumberPages)
          .Must(a => a > 0)
          .WithMessage("Number of pages must be positive");

        RuleFor(request => request.YearPublishing)
          .Must(a => a > 0)
          .WithMessage("Year of publishing must be positive");
    }
}