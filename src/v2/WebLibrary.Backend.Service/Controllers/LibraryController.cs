using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebLibrary.Backend.Models.DTO.Requests.Library;
using WebLibrary.Backend.Models.DTO.Responses.Library;
using WebLibraryService.Backend.Domain.Interfaces;

namespace WebLibrary.Controllers;

[Authorize]
[ApiController]
[Route("api/library")]
public class LibraryController(
    [FromServices] ILibraryService service) : ControllerBase
{
    [HttpPost("create")]
    public async Task<int> CreateLibrary(
        [FromBody] CreateLibraryRequest request,
        CancellationToken token)
    {
        return await service.CreateAsync(request, token);
    }

    [HttpGet("get")]
    public async Task<GetLibraryResponse> GetLibrary([FromQuery] int number, CancellationToken token)
    {
        return await service.GetAsync(number, token);
    }

    [HttpGet("get/all")]
    public async Task<List<GetLibraryResponse>> GetLibraries(CancellationToken token)
    {
        return await service.GetAllAsync(token);
    }

    [HttpPut("update")]
    public async Task UpdateLibrary(
        [FromBody] UpdateLibraryRequest request,
        CancellationToken token)
    {
        await service.UpdateAsync(request, token);
    }

    [HttpDelete("delete")]
    public async Task DeleteLibrary(
        [FromQuery] int number,
        CancellationToken token)
    {
        await service.DeleteAsync(number, token);
    }
}
