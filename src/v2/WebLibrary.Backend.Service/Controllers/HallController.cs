using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebLibrary.Backend.Models.DTO.Requests.Hall;
using WebLibrary.Backend.Models.DTO.Responses.Hall;
using WebLibraryService.Backend.Domain.Interfaces;

namespace WebLibrary.Controllers;

[Authorize]
[ApiController]
[Route("api/hall")]
public class HallController(
    [FromServices] IHallService service) : ControllerBase
{
    [HttpPost("create")]
    public async Task<uint> CreateHall(
        [FromBody] CreateHallRequest request,
        CancellationToken token)
    {
        return await service.CreateAsync(request, token);
    }

    [HttpGet("get")]
    public async Task<GetHallResponse> GetHall(
        [FromQuery] int libraryNumber,
        [FromQuery] uint number,
        CancellationToken token)
    {
        return await service.GetAsync(libraryNumber, number, token);
    }

    [HttpGet("get/all")]
    public async Task<List<GetHallResponse>> GetHalls(CancellationToken token)
    {
        return await service.GetAllAsync(token);
    }

    [HttpPut("update")]
    public async Task UpdateHall(
        [FromBody] UpdateHallRequest request,
        CancellationToken token)
    {
        await service.UpdateAsync(request, token);
    }

    [HttpDelete("delete")]
    public async Task DeleteHall(
        [FromQuery] int libraryNumber,
        [FromQuery] uint number,
        CancellationToken token)
    {
        await service.DeleteAsync(libraryNumber, number, token);
    }
}
