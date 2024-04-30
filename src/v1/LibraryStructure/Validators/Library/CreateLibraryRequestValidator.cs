using FluentValidation;
using ServiceModels.Requests.Library;

namespace LibraryStructure.Validators.Library;

public class CreateLibraryRequestValidator : AbstractValidator<CreateLibraryRequest>, ICreateLibraryRequestValidator
{
    public CreateLibraryRequestValidator()
    {

    }
}