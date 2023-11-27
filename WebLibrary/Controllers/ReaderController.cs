using Microsoft.AspNetCore.Mvc;
using WebLibrary.Commands.Reader.Interfaces;
using WebLibrary.Requests;

namespace WebLibrary.Controllers;

[Route("[controller]")]
[ApiController]
public class ReaderController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
    [FromServices] ICreaterReader action,
    [FromBody] CreateReaderRequest request)
    {
        return await action.CreateAsync(request);
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetReaderAsync(
    [FromServices] IReaderReader action,
    [FromQuery] Guid id)
    {
        return await action.GetAsync(id);
    }

    [HttpGet]
    public IActionResult GetAll(
    [FromServices] IReaderReader action)
    {
        return action.Get();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(
    [FromServices] IUpdaterReader action,
    [FromQuery] Guid id,
    [FromBody] CreateReaderRequest request)
    {
        return await action.UpdateAsync(id, request);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(
    [FromServices] IDeleterReader action,
    [FromQuery] Guid id)
    {
        return await action.DeleteAsync(id);
    }
}