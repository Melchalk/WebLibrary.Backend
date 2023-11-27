using Microsoft.AspNetCore.Mvc;
using WebLibrary.Commands.Issue.Interfaces;
using WebLibrary.Requests;

namespace ProxyLibrary.Controllers;

[Route("[controller]")]
[ApiController]
public class IssueController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
    [FromServices] ICreaterIssue action,
    [FromBody] CreateIssueRequest request)
    {
        return await action.CreateAsync(request);
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetIssueAsync(
    [FromServices] IReaderIssue action,
    [FromQuery] Guid id)
    {
        return await action.GetAsync(id);
    }

    [HttpGet]
    public IActionResult GetAll(
    [FromServices] IReaderIssue action)
    {
        return action.Get();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(
    [FromServices] IUpdaterIssue action,
    [FromQuery] Guid id,
    [FromBody] CreateIssueRequest request)
    {
        return await action.UpdateAsync(id, request);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(
    [FromServices] IDeleterIssue action,
    [FromQuery] Guid id)
    {
        return await action.DeleteAsync(id);
    }
}