using FluentValidation;
using WebLibrary.ModelRequest;

namespace WebLibrary.Validators;

public class CreateBookRequestValidator : AbstractValidator<BookRequest>, ICreateBookRequestValidator
{
    //проверка на цифры
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