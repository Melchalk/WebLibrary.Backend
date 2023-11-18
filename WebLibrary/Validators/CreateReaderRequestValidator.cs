using FluentValidation;
using WebLibrary.ModelRequest;

namespace WebLibrary.Validators;

public class CreateReaderRequestValidator : AbstractValidator<ReaderRequest>, ICreateReaderRequestValidator
{
    public CreateReaderRequestValidator()
    {
        RuleFor(request => request.Fullname)
          .NotEmpty()
          .WithMessage("Fullname should not be empty");

        RuleFor(request => request.Age)
          .Must(a => a >= 14)
          .WithMessage("The age must be over 14");

        When(request => request.Age < 14 || request.RegistrationAddress is null, () =>
        {
            RuleFor(request => request.CanTakeBooks)
              .Must(a => a == false)
              .WithMessage("If age < 14 or registration address is unknown\nThe reader cannot take books");
        });
    }
}
