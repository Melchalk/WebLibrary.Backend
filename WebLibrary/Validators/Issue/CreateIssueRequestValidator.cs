using FluentValidation;
using ServiceModels.Requests.Book;

namespace WebLibrary.Validators.Book;

public class CreateIssueRequestValidator : AbstractValidator<CreateBookRequest>, ICreateBookRequestValidator
{
    public CreateIssueRequestValidator()
    {

    }
}