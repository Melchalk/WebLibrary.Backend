using Microsoft.AspNetCore.Mvc;
using ProxyLibrary.Publishers;
using ServiceModels.Requests.Library;
using ServiceModels.Responses.Library;

namespace ProxyLibrary.Controllers;

[Route("[controller]")]
[ApiController]
public class LibraryController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromServices] IMessagePublisher<CreateLibraryRequest, CreateLibraryResponse> messagePublisher,
        [FromBody] CreateLibraryRequest request)
    {
        CreateLibraryResponse libraryResponse = await messagePublisher.SendMessageAsync(request);

        if (libraryResponse.Id is null)
        {
            return BadRequest(libraryResponse.Errors);
        }

        return Created("Librarys", libraryResponse.Id);
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetLibraryAsync(
        [FromServices] IMessagePublisher<GetLibraryRequest, GetLibraryResponse> messagePublisher,
        [FromQuery] Guid id)
    {
        GetLibraryRequest getRequest = new()
        {
            Id = id
        };

        GetLibraryResponse libraryResponse = await messagePublisher.SendMessageAsync(getRequest);

        if (libraryResponse.Error is not null)
        {
            return BadRequest(libraryResponse.Error);
        }

        return Ok(libraryResponse);
    }

    [HttpGet()]
    public async Task<IActionResult> GetAllAsync(
        [FromServices] IMessagePublisher<GetLibrariesRequest, GetLibrariesResponse> messagePublisher)
    {
        GetLibrariesRequest getRequest = new();

        GetLibrariesResponse libraryResponse = await messagePublisher.SendMessageAsync(getRequest);

        return Ok(libraryResponse.LibraryResponses);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(
        [FromServices] IMessagePublisher<UpdateLibraryRequest, UpdateLibraryResponse> messagePublisher,
        [FromQuery] Guid id,
        [FromBody] CreateLibraryRequest request)
    {
        UpdateLibraryRequest updateRequest = new()
        {
            Id = id,
            CreateLibraryRequest = request
        };

        UpdateLibraryResponse libraryResponse = await messagePublisher.SendMessageAsync(updateRequest);

        if (libraryResponse.Result == false)
        {
            return BadRequest(libraryResponse.Errors);
        }

        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(
        [FromServices] IMessagePublisher<DeleteLibraryRequest, DeleteLibraryResponse> messagePublisher,
        [FromQuery] Guid id)
    {
        DeleteLibraryRequest deleteRequest = new()
        {
            Id = id
        };

        DeleteLibraryResponse libraryResponse = await messagePublisher.SendMessageAsync(deleteRequest);

        if (libraryResponse.Error is not null)
        {
            return BadRequest(libraryResponse.Error);
        }

        return Ok();
    }
}