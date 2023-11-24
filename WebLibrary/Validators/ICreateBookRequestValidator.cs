using FluentValidation;
using WebLibrary.ModelRequest;

namespace WebLibrary.Validators;

public interface ICreateBookRequestValidator : IValidator<CreateBookRequest>
{
}