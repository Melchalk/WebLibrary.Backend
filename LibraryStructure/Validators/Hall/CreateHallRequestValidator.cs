using FluentValidation;
using ServiceModels.Requests.Hall;

namespace LibraryStructure.Validators.Hall;
public class CreateHallRequestValidator : AbstractValidator<CreateHallRequest>, ICreateHallRequestValidator
{
    public CreateHallRequestValidator()
    {
        RuleFor(request => request.No)
            .Must(a => a > 0)
            .WithMessage("Number of hall must be positive");
    }
}