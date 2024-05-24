using FluentValidation;
using ServiceModels.Requests.Book;

namespace WebLibrary.Validators.Book;

public interface ICreateBookRequestValidator : IValidator<CreateBookRequest>
{
}