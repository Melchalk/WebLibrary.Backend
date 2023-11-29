using FluentValidation;
using ServiceModels.Requests.Book;

namespace WebLibrary.Validators;

public interface ICreateBookRequestValidator : IValidator<CreateBookRequest>
{
}