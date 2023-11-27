using Microsoft.AspNetCore.Mvc;
using WebLibrary.Commands.Hall.Interfaces;
using WebLibrary.Requests;

namespace ProxyLibrary.Controllers;

[Route("[controller]")]
[ApiController]
public class HallController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
    [FromServices] ICreaterHall action,
    [FromBody] CreateHallRequest request)
    {
        return await action.CreateAsync(request);
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetHallAsync(
    [FromServices] IReaderHall action,
    [FromQuery] Guid id)
    {
        return await action.GetAsync(id);
    }

    [HttpGet]
    public IActionResult GetAll(
    [FromServices] IReaderHall action)
    {
        return action.Get();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(
    [FromServices] IUpdaterHall action,
    [FromQuery] Guid id,
    [FromBody] CreateHallRequest request)
    {
        return await action.UpdateAsync(id, request);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(
    [FromServices] IDeleterHall action,
    [FromQuery] Guid id)
    {
        return await action.DeleteAsync(id);
    }
}