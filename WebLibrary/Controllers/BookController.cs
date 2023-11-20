using Microsoft.AspNetCore.Mvc;
using WebLibrary.BooksOptions;
using WebLibrary.ModelRequest;

namespace WebLibrary.Controllers;

[Route("[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    [HttpPost]
    public IActionResult Create(
    [FromServices] IBookActions action,
    [FromBody] BookRequest request)
    {
        return action.Create(request);
    }

    [HttpGet("id")]
    public IActionResult GetBook(
    [FromServices] IBookActions action,
    [FromQuery] Guid id)
    {
        return action.Get(id);
    }

    [HttpGet]
    public IActionResult GetAll(
    [FromServices] IBookActions action)
    {
        return action.Get();
    }

    [HttpPut]
    public IActionResult Update(
    [FromServices] IBookActions action,
    [FromQuery] Guid id,
    [FromBody] BookRequest request)
    {
        return action.Update(id, request);
    }

    [HttpDelete]
    public IActionResult Delete(
    [FromServices] IBookActions action,
    [FromQuery] Guid id)
    {
        return action.Delete(id);
    }
}