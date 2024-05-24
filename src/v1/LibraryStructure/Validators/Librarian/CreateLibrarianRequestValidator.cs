using FluentValidation;
using ServiceModels.Requests.Librarian;

namespace LibraryStructure.Validators.Librarian;

public class CreateLibrarianRequestValidator : AbstractValidator<CreateLibrarianRequest>, ICreateLibrarianRequestValidator
{
    public CreateLibrarianRequestValidator()
    {

    }
}