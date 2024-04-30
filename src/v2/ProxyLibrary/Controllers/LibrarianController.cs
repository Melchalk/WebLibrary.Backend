using Microsoft.AspNetCore.Mvc;
using ProxyLibrary.Publishers;
using ServiceModels.Requests.Librarian;
using ServiceModels.Responses.Librarian;

namespace ProxyLibrary.Controllers;

[Route("[controller]")]
[ApiController]
public class LibrarianController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromServices] IMessagePublisher<CreateLibrarianRequest, CreateLibrarianResponse> messagePublisher,
        [FromBody] CreateLibrarianRequest request)
    {
        CreateLibrarianResponse librarianResponse = await messagePublisher.SendMessageAsync(request);

        if (librarianResponse.Id is null)
        {
            return BadRequest(librarianResponse.Errors);
        }

        return Created("Librarians", librarianResponse.Id);
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetLibrarianAsync(
        [FromServices] IMessagePublisher<GetLibrarianRequest, GetLibrarianResponse> messagePublisher,
        [FromQuery] Guid id)
    {
        GetLibrarianRequest getRequest = new()
        {
            Id = id
        };

        GetLibrarianResponse librarianResponse = await messagePublisher.SendMessageAsync(getRequest);

        if (librarianResponse.Error is not null)
        {
            return BadRequest(librarianResponse.Error);
        }

        return Ok(librarianResponse);
    }

    [HttpGet()]
    public async Task<IActionResult> GetAllAsync(
        [FromServices] IMessagePublisher<GetLibrariansRequest, GetLibrariansResponse> messagePublisher)
    {
        GetLibrariansRequest getRequest = new();

        GetLibrariansResponse librarianResponse = await messagePublisher.SendMessageAsync(getRequest);

        return Ok(librarianResponse.LibrarianResponses);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(
        [FromServices] IMessagePublisher<UpdateLibrarianRequest, UpdateLibrarianResponse> messagePublisher,
        [FromQuery] Guid id,
        [FromBody] CreateLibrarianRequest request)
    {
        UpdateLibrarianRequest updateRequest = new()
        {
            Id = id,
            CreateLibrarianRequest = request
        };

        UpdateLibrarianResponse librarianResponse = await messagePublisher.SendMessageAsync(updateRequest);

        if (librarianResponse.Result == false)
        {
            return BadRequest(librarianResponse.Errors);
        }

        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(
        [FromServices] IMessagePublisher<DeleteLibrarianRequest, DeleteLibrarianResponse> messagePublisher,
        [FromQuery] Guid id)
    {
        DeleteLibrarianRequest deleteRequest = new()
        {
            Id = id
        };

        DeleteLibrarianResponse librarianResponse = await messagePublisher.SendMessageAsync(deleteRequest);

        if (librarianResponse.Error is not null)
        {
            return BadRequest(librarianResponse.Error);
        }

        return Ok();
    }
}