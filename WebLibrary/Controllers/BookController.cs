using Microsoft.AspNetCore.Mvc;
using WebLibrary.BooksOptions;
using WebLibrary.ModelRequest;
using WebLibrary.ModelsResponses.BookResponses;

namespace WebLibrary.Controllers;

[Route("[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    [HttpPost]
    public CreateBookResponse Create(
    [FromServices] IBookActions action,
    [FromBody] BookRequest request)
    {
        return action.Create(request);
    }

    [HttpGet]
    public GetBookResponse Get(
    [FromServices] IBookActions action,
    [FromQuery] Guid id)
    {
        return action.Get(id);
    }

    [HttpPut]
    public UpdateBookResponse Update(
    [FromServices] IBookActions action,
    [FromQuery] Guid id,
    [FromBody] BookRequest request)
    {
        return action.Update(id, request);
    }

    [HttpDelete]
    public DeleteBookResponse Delete(
    [FromServices] IBookActions action,
    [FromQuery] Guid id)
    {
        return action.Delete(id);
    }
}