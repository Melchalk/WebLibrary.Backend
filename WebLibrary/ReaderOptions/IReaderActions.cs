using Microsoft.AspNetCore.Mvc;
using WebLibrary.Requests;

namespace WebLibrary.ReaderOptions;

public interface IReaderActions
{
    IActionResult Create(CreateReaderRequest request);

    IActionResult Get(Guid id);

    IActionResult Get();

    IActionResult Update(Guid id, CreateReaderRequest request);

    IActionResult Delete(Guid id);
}