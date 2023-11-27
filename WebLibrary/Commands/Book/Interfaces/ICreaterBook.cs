using Microsoft.AspNetCore.Mvc;
using WebLibrary.Commands.Common_interfaces;
using WebLibrary.Requests;

namespace WebLibrary.Commands.Book.Interfaces;

public interface ICreaterBook : ICreater<CreateBookRequest>
{

}
