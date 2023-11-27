using Microsoft.AspNetCore.Mvc;
using WebLibrary.Commands.Book.Interfaces;
using WebLibrary.Requests;

namespace WebLibrary.Controllers;

[Route("[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
    [FromServices] ICreaterBook action,
    [FromBody] CreateBookRequest request)
    {
        return await action.CreateAsync(request);
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetBookAsync(
    [FromServices] IReaderBook action,
    [FromQuery] Guid id)
    {
        return await action.GetAsync(id);
    }

    [HttpGet]
    public IActionResult GetAll(
    [FromServices] IReaderBook action)
    {
        return action.Get();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(
    [FromServices] IUpdaterBook action,
    [FromQuery] Guid id,
    [FromBody] CreateBookRequest request)
    {
        return await action.UpdateAsync(id, request);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(
    [FromServices] IDeleterBook action,
    [FromQuery] Guid id)
    {
        return await action.DeleteAsync(id);
    }
}