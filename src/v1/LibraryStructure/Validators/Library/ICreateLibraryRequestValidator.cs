using FluentValidation;
using ServiceModels.Requests.Library;

namespace LibraryStructure.Validators.Library;

public interface ICreateLibraryRequestValidator : IValidator<CreateLibraryRequest>
{
}