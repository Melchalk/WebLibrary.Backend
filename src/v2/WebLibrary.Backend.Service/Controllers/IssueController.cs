using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebLibrary.Backend.Models.DTO.Requests.Issue;
using WebLibrary.Backend.Models.DTO.Responses.Issue;
using WebLibraryService.Backend.Domain.Interfaces;

namespace WebLibrary.Controllers;

[Authorize]
[ApiController]
[Route("api/issue")]
public class IssueController(
    [FromServices] IIssueService service) : ControllerBase
{
    [HttpPost("create")]
    public async Task<Guid?> CreateIssue(
        [FromBody] CreateIssueRequest request,
        CancellationToken token)
    {
        return await service.CreateAsync(request, token);
    }

    [HttpGet("get")]
    public async Task<GetIssueResponse> GetIssue([FromQuery] Guid id, CancellationToken token)
    {
        return await service.GetAsync(id, token);
    }

    [HttpGet("get/all")]
    public async Task<List<GetIssueResponse>> GetIssues(CancellationToken token)
    {
        return await service.GetAllAsync(token);
    }

    [HttpPut("update")]
    public async Task UpdateIssue(
        [FromBody] UpdateIssueRequest request,
        CancellationToken token)
    {
        await service.UpdateAsync(request, token);
    }

    [HttpDelete("delete")]
    public async Task DeleteIssue(
        [FromQuery] Guid id,
        CancellationToken token)
    {
        await service.DeleteAsync(id, token);
    }
}
