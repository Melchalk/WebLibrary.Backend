using Microsoft.AspNetCore.Mvc;
using WebLibrary.ModelRequest;
using WebLibrary.Requests;

namespace WebLibrary.BooksOptions;

public interface IBookActions
{
    IActionResult Create(CreateBookRequest request);

    IActionResult Get(Guid id);

    IActionResult Get();

    IActionResult Update(Guid id, CreateBookRequest request);

    IActionResult Delete(Guid id);
}