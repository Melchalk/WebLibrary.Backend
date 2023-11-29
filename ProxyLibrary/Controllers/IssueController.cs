using Microsoft.AspNetCore.Mvc;
using ProxyLibrary.Publishers;
using ServiceModels.Requests.Issue;
using ServiceModels.Responses.Issue;

namespace ProxyLibrary.Controllers;

[Route("[controller]")]
[ApiController]
public class IssueController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
    [FromServices] IMessagePublisher<CreateIssueRequest, CreateIssueResponse> messagePublisher,
    [FromBody] CreateIssueRequest request)
    {
        CreateIssueResponse issueResponse = await messagePublisher.SendMessageAsync(request);

        if (issueResponse.Id is null)
        {
            return BadRequest(issueResponse.Errors);
        }

        return Created("Issues", issueResponse.Id);
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetIssueAsync(
    [FromServices] IMessagePublisher<GetIssueRequest, GetIssueResponse> messagePublisher,
    [FromQuery] Guid id)
    {
        GetIssueRequest getRequest = new() { Id = id };

        GetIssueResponse issueResponse = await messagePublisher.SendMessageAsync(getRequest);

        if (issueResponse.Error is not null)
        {
            return BadRequest(issueResponse.Error);
        }

        return Ok(issueResponse);
    }

    [HttpGet()]
    public async Task<IActionResult> GetAllAsync(
    [FromServices] IMessagePublisher<GetIssuesRequest, GetIssuesResponse> messagePublisher)
    {
        GetIssuesRequest getRequest = new();

        GetIssuesResponse issueResponse = await messagePublisher.SendMessageAsync(getRequest);

        return Ok(issueResponse);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(
    [FromServices] IMessagePublisher<UpdateIssueRequest, UpdateIssueResponse> messagePublisher,
    [FromQuery] Guid id,
    [FromBody] CreateIssueRequest request)
    {
        UpdateIssueRequest updateRequest = new() { Id = id, CreateIssueRequest = request };

        UpdateIssueResponse issueResponse = await messagePublisher.SendMessageAsync(updateRequest);

        if (issueResponse.Result == false)
        {
            return BadRequest(issueResponse.Errors);
        }

        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(
    [FromServices] IMessagePublisher<DeleteIssueRequest, DeleteIssueResponse> messagePublisher,
    [FromQuery] Guid id)
    {
        DeleteIssueRequest deleteRequest = new() { Id = id };

        DeleteIssueResponse issueResponse = await messagePublisher.SendMessageAsync(deleteRequest);

        if (issueResponse.Error is not null)
        {
            return BadRequest(issueResponse.Error);
        }

        return Ok();
    }
}