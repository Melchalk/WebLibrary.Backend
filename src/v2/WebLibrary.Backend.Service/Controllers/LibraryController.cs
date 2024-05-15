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
    public async Task<Guid?> CreateLibrary(
        [FromBody] CreateLibraryRequest request,
        CancellationToken token)
    {
        return await service.CreateAsync(request, token);
    }

    [HttpGet("get")]
    public async Task<GetLibraryResponse> GetLibrary([FromQuery] Guid id, CancellationToken token)
    {
        return await service.GetAsync(id, token);
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
        [FromQuery] Guid id,
        CancellationToken token)
    {
        await service.DeleteAsync(id, token);
    }
}
