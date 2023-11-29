using FluentValidation;
using ServiceModels.Requests.Hall;

namespace LibraryStructure.Validators.Hall;
public class CreateHallRequestValidator : AbstractValidator<CreateHallRequest>, ICreateHallRequestValidator
{
    public CreateHallRequestValidator()
    {

    }
}