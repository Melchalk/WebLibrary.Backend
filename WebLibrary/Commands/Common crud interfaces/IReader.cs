using Microsoft.AspNetCore.Mvc;

namespace WebLibrary.Commands.Common_interfaces;

public interface IReader
{
    Task<IActionResult> GetAsync(Guid id);

    IActionResult Get();
}
