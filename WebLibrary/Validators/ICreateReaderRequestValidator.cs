using FluentValidation;
using ServiceModels.Requests.Reader;

namespace WebLibrary.Validators;

public interface ICreateReaderRequestValidator : IValidator<CreateReaderRequest>
{
}