using Microsoft.AspNetCore.Mvc;
using WebLibrary.Requests;
using WebLibrary.ReaderOptions;

namespace WebLibrary.Controllers;

[Route("[controller]")]
[ApiController]
public class ReaderController : ControllerBase
{
    [HttpPost]
    public IActionResult Create(
    [FromServices] IReaderActions action,
    [FromBody] CreateReaderRequest request)
    {
        return action.Create(request);
    }

    [HttpGet("id")]
    public IActionResult GetReader(
    [FromServices] IReaderActions action,
    [FromQuery] Guid id)
    {
        return action.Get(id);
    }

    [HttpGet]
    public IActionResult GetAll(
    [FromServices] IReaderActions action)
    {
        return action.Get();
    }

    [HttpPut]
    public IActionResult Update(
    [FromServices] IReaderActions action,
    [FromQuery] Guid id,
    [FromBody] CreateReaderRequest request)
    {
        return action.Update(id, request);
    }

    [HttpDelete]
    public IActionResult Delete(
    [FromServices] IReaderActions action,
    [FromQuery] Guid id)
    {
        return action.Delete(id);
    }
}