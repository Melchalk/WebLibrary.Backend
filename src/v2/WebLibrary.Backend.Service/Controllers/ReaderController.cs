using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebLibrary.Backend.Models.DTO.Requests.Reader;
using WebLibrary.Backend.Models.DTO.Responses.Reader;
using WebLibraryService.Backend.Domain.Interfaces;

namespace WebLibrary.Controllers;

[Authorize]
[ApiController]
[Route("api/Reader")]
public class ReaderController(
    [FromServices] IReaderService service) : ControllerBase
{
    [HttpPost("create")]
    public async Task<Guid?> CreateReader(
        [FromBody] CreateReaderRequest request,
        CancellationToken token)
    {
        return await service.CreateAsync(request, token);
    }

    [HttpGet("get")]
    public async Task<GetReaderResponse> GetReader([FromQuery] Guid id, CancellationToken token)
    {
        return await service.GetAsync(id, token);
    }

    [HttpGet("get/all")]
    public async Task<List<GetReaderResponse>> GetReaders(CancellationToken token)
    {
        return await service.GetAllAsync(token);
    }

    [HttpPut("update")]
    public async Task UpdateReader(
        [FromBody] UpdateReaderRequest request,
        CancellationToken token)
    {
        await service.UpdateAsync(request, token);
    }

    [HttpDelete("delete")]
    public async Task DeleteReader(
        [FromQuery] Guid id,
        CancellationToken token)
    {
        await service.DeleteAsync(id, token);
    }
}
