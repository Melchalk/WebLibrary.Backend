using Microsoft.AspNetCore.Mvc;
using ProxyLibrary.Publishers;
using ServiceModels.Requests.Hall;
using ServiceModels.Responses.Hall;

namespace ProxyLibrary.Controllers;

[Route("[controller]")]
[ApiController]
public class HallController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromServices] IMessagePublisher<CreateHallRequest, CreateHallResponse> messagePublisher,
        [FromBody] CreateHallRequest request)
    {
        CreateHallResponse hallResponse = await messagePublisher.SendMessageAsync(request);

        if (hallResponse.LibraryId is null)
        {
            return BadRequest(hallResponse.Errors);
        }

        return Created("Halls", new { hallResponse.LibraryId, hallResponse.No });
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetHallAsync(
        [FromServices] IMessagePublisher<GetHallRequest, GetHallResponse> messagePublisher,
        [FromQuery] Guid libraryId,
        [FromQuery] int number)
    {
        GetHallRequest getRequest = new()
        {
            LibraryId = libraryId,
            No = number
        };

        GetHallResponse hallResponse = await messagePublisher.SendMessageAsync(getRequest);

        if (hallResponse.Error is not null)
        {
            return BadRequest(hallResponse.Error);
        }

        return Ok(hallResponse);
    }

    [HttpGet()]
    public async Task<IActionResult> GetAllAsync(
        [FromServices] IMessagePublisher<GetHallsRequest, GetHallsResponse> messagePublisher)
    {
        GetHallsRequest getRequest = new();

        GetHallsResponse hallResponse = await messagePublisher.SendMessageAsync(getRequest);

        return Ok(hallResponse.HallResponses);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(
        [FromServices] IMessagePublisher<UpdateHallRequest, UpdateHallResponse> messagePublisher,
        [FromBody] CreateHallRequest request)
    {
        UpdateHallRequest updateRequest = new() { CreateHallRequest = request };

        UpdateHallResponse hallResponse = await messagePublisher.SendMessageAsync(updateRequest);

        if (hallResponse.Result == false)
        {
            return BadRequest(hallResponse.Errors);
        }

        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(
        [FromServices] IMessagePublisher<DeleteHallRequest, DeleteHallResponse> messagePublisher,
        [FromQuery] Guid libraryId,
        [FromQuery] int number)
    {
        DeleteHallRequest deleteRequest = new()
        {
            LibraryId = libraryId,
            No = number
        };

        DeleteHallResponse hallResponse = await messagePublisher.SendMessageAsync(deleteRequest);

        if (hallResponse.Error is not null)
        {
            return BadRequest(hallResponse.Error);
        }

        return Ok();
    }
}