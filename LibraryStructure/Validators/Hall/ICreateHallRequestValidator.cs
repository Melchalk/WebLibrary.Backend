using FluentValidation;
using ServiceModels.Requests.Hall;

namespace LibraryStructure.Validators.Hall;

public interface ICreateHallRequestValidator : IValidator<CreateHallRequest>
{
}