using Microsoft.AspNetCore.Mvc;
using ProxyLibrary.Publishers;
using ServiceModels.Requests.Reader;
using ServiceModels.Responses.Reader;

namespace ProxyLibrary.Controllers;

[Route("[controller]")]
[ApiController]
public class ReaderController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromServices] IMessagePublisher<CreateReaderRequest, CreateReaderResponse> messagePublisher,
        [FromBody] CreateReaderRequest request)
    {
        CreateReaderResponse readerResponse = await messagePublisher.SendMessageAsync(request);

        if (readerResponse.Id is null)
        {
            return BadRequest(readerResponse.Errors);
        }

        return Created("Readers", readerResponse.Id);
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetReaderAsync(
        [FromServices] IMessagePublisher<GetReaderRequest, GetReaderResponse> messagePublisher,
        [FromQuery] Guid id)
    {
        GetReaderRequest getRequest = new() { Id = id };

        GetReaderResponse readerResponse = await messagePublisher.SendMessageAsync(getRequest);

        if (readerResponse.Error is not null)
        {
            return BadRequest(readerResponse.Error);
        }

        return Ok(readerResponse);
    }

    [HttpGet()]
    public async Task<IActionResult> GetAllAsync(
        [FromServices] IMessagePublisher<GetReadersRequest, GetReadersResponse> messagePublisher)
    {
        GetReadersRequest getRequest = new();

        GetReadersResponse readerResponse = await messagePublisher.SendMessageAsync(getRequest);

        return Ok(readerResponse);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(
        [FromServices] IMessagePublisher<UpdateReaderRequest, UpdateReaderResponse> messagePublisher,
        [FromQuery] Guid id,
        [FromBody] CreateReaderRequest request)
    {
        UpdateReaderRequest updateRequest = new() { Id = id, CreateReaderRequest = request };

        UpdateReaderResponse readerResponse = await messagePublisher.SendMessageAsync(updateRequest);

        if (readerResponse.Result == false)
        {
            return BadRequest(readerResponse.Errors);
        }

        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(
        [FromServices] IMessagePublisher<DeleteReaderRequest, DeleteReaderResponse> messagePublisher,
        [FromQuery] Guid id)
    {
        DeleteReaderRequest deleteRequest = new() { Id = id };

        DeleteReaderResponse readerResponse = await messagePublisher.SendMessageAsync(deleteRequest);

        if (readerResponse.Error is not null)
        {
            return BadRequest(readerResponse.Error);
        }

        return Ok();
    }
}