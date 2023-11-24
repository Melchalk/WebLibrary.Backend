using FluentValidation;
using WebLibrary.Requests;

namespace WebLibrary.Validators;

public interface ICreateReaderRequestValidator : IValidator<CreateReaderRequest>
{
}