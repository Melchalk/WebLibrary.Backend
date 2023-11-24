using FluentValidation;
using WebLibrary.Requests;

namespace WebLibrary.Validators;

public class CreateBookRequestValidator : AbstractValidator<CreateBookRequest>, ICreateBookRequestValidator
{
    public CreateBookRequestValidator()
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