using FluentValidation;
using ServiceModels.Requests.Reader;

namespace WebLibrary.Validators.Reader;

public interface ICreateReaderRequestValidator : IValidator<CreateReaderRequest>
{
}