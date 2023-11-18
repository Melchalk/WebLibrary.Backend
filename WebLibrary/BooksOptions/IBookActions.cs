using Microsoft.AspNetCore.Mvc;
using WebLibrary.ModelRequest;

namespace WebLibrary.BooksOptions;

public interface IBookActions
{
    IActionResult Create(BookRequest request);

    IActionResult Get(Guid id);

    IActionResult Get();

    IActionResult Update(Guid id, BookRequest request);

    IActionResult Delete(Guid id);
}