using Microsoft.AspNetCore.Mvc;
using ProxyLibrary.Publishers;
using ServiceModels.Requests.Book;
using ServiceModels.Responses.Book;

namespace ProxyLibrary.Controllers;

[Route("[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromServices] IMessagePublisher<CreateBookRequest, CreateBookResponse> messagePublisher,
        [FromBody] CreateBookRequest request)
    {
        CreateBookResponse bookResponse = await messagePublisher.SendMessageAsync(request);

        if (bookResponse.Id is null)
        {
            return BadRequest(bookResponse.Errors);
        }

        return Created("Books", bookResponse.Id);
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetBookAsync(
        [FromServices] IMessagePublisher<GetBookRequest, GetBookResponse> messagePublisher,
        [FromQuery] Guid id)
    {
        GetBookRequest getRequest = new() { Id = id };

        GetBookResponse bookResponse = await messagePublisher.SendMessageAsync(getRequest);

        if (bookResponse.Error is not null)
        {
            return BadRequest(bookResponse.Error);
        }

        return Ok(bookResponse);
    }

    [HttpGet()]
    public async Task<IActionResult> GetAllAsync(
        [FromServices] IMessagePublisher<GetBooksRequest, GetBooksResponse> messagePublisher)
    {
        GetBooksRequest getRequest = new();

        GetBooksResponse bookResponse = await messagePublisher.SendMessageAsync(getRequest);

        return Ok(bookResponse.BookResponses);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(
        [FromServices] IMessagePublisher<UpdateBookRequest, UpdateBookResponse> messagePublisher,
        [FromQuery] Guid id,
        [FromBody] CreateBookRequest request)
    {
        UpdateBookRequest updateRequest = new()
        {
            Id = id,
            CreateBookRequest = request
        };

        UpdateBookResponse bookResponse = await messagePublisher.SendMessageAsync(updateRequest);

        if (bookResponse.Result == false)
        {
            return BadRequest(bookResponse.Errors);
        }

        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(
        [FromServices] IMessagePublisher<DeleteBookRequest, DeleteBookResponse> messagePublisher,
        [FromQuery] Guid id)
    {
        DeleteBookRequest deleteRequest = new() { Id = id };

        DeleteBookResponse bookResponse = await messagePublisher.SendMessageAsync(deleteRequest);

        if (bookResponse.Error is not null)
        {
            return BadRequest(bookResponse.Error);
        }

        return Ok();
    }
}