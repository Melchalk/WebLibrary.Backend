using FluentValidation;
using ServiceModels.Requests.Librarian;

namespace LibraryStructure.Validators.Librarian;

public interface ICreateLibrarianRequestValidator : IValidator<CreateLibrarianRequest>
{
}