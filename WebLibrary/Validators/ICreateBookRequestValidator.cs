using FluentValidation;
using WebLibrary.Requests;

namespace WebLibrary.Validators;

public interface ICreateBookRequestValidator : IValidator<CreateBookRequest>
{
}