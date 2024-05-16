using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebLibrary.Backend.Models.DTO.Requests.Book;
using WebLibrary.Backend.Models.DTO.Responses.Book;
using WebLibraryService.Backend.Domain.Interfaces;

namespace WebLibrary.Controllers;

[Authorize]
[ApiController]
[Route("api/book")]
public class BookController(
    [FromServices] IBookService service) : ControllerBase
{
    [HttpPost("create")]
    public async Task<Guid?> CreateBook(
        [FromBody] CreateBookRequest request,
        CancellationToken token)
    {
        return await service.CreateAsync(request, token);
    }

    [HttpGet("get")]
    public async Task<GetBookResponse> GetBook([FromQuery]Guid id, CancellationToken token)
    {
        return await service.GetAsync(id, token);
    }

    [HttpGet("get/all")]
    public async Task<List<GetBookResponse>> GetBooks([FromQuery] int libraryNumber, CancellationToken token)
    {
        return await service.GetAllAsync(libraryNumber, token);
    }

    [HttpPut("update")]
    public async Task UpdateBook(
        [FromBody] UpdateBookRequest request,
        CancellationToken token)
    {
        await service.UpdateAsync(request, token);
    }

    [HttpDelete("delete")]
    public async Task DeleteBook(
        [FromQuery] Guid id,
        CancellationToken token)
    {
        await service.DeleteAsync(id, token);
    }
}
