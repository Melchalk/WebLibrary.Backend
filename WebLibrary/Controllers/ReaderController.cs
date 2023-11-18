using Microsoft.AspNetCore.Mvc;
using WebLibrary.BooksOptions;
using WebLibrary.ModelRequest;
using WebLibrary.ModelsResponses.ReaderResponses;
using WebLibrary.ReaderOptions;

namespace WebLibrary.Controllers;

[Route("[controller]")]
[ApiController]
public class ReaderController : ControllerBase
{
    [HttpPost]
    public CreateReaderResponse Create(
    [FromServices] IReaderActions action,
    [FromBody] ReaderRequest request)
    {
        return action.Create(request);
    }

    [HttpGet]
    public GetReaderResponse Get(
    [FromServices] IReaderActions action,
    [FromQuery] Guid id)
    {
        return action.Get(id);
    }

    [HttpPut]
    public UpdateReaderResponse Update(
    [FromServices] IReaderActions action,
    [FromQuery] Guid id,
    [FromBody] ReaderRequest request)
    {
        return action.Update(id, request);
    }

    [HttpDelete]
    public DeleteReaderResponse Delete(
    [FromServices] IReaderActions action,
    [FromQuery] Guid id)
    {
        return action.Delete(id);
    }
}