using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebLibrary.Backend.Models.DTO.Requests.Librarian;
using WebLibrary.Backend.Models.DTO.Responses.Librarian;
using WebLibraryService.Backend.Domain.Interfaces;

namespace WebLibrary.Controllers;

[Authorize]
[ApiController]
[Route("api/librarian")]
public class LibrarianController(
    [FromServices] ILibrarianService service) : ControllerBase
{
    [HttpGet("get")]
    public async Task<GetLibrarianResponse> GetLibrarian([FromQuery] Guid id, CancellationToken token)
    {
        return await service.GetAsync(id, token);
    }

    [HttpGet("get/all")]
    public async Task<List<GetLibrarianResponse>> GetLibrarians(CancellationToken token)
    {
        return await service.GetAllAsync(token);
    }

    [HttpPut("update")]
    public async Task UpdateLibrarian(
        [FromBody] UpdateLibrarianRequest request,
        CancellationToken token)
    {
        await service.UpdateAsync(request, token);
    }

    [HttpDelete("delete")]
    public async Task DeleteLibrarian(
        [FromQuery] Guid id,
        CancellationToken token)
    {
        await service.DeleteAsync(id, token);
    }
}
