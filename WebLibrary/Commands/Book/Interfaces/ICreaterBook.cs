using ServiceModels.Requests.Book;
using ServiceModels.Responses.Book;
using WebLibrary.Commands.Common_interfaces;

namespace WebLibrary.Commands.Book.Interfaces;

public interface ICreaterBook : ICreater<CreateBookRequest, CreateBookResponse>
{
}