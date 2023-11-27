using Microsoft.AspNetCore.Mvc;

namespace WebLibrary.Commands.Common_interfaces;

public interface ICreater<T>
{
    Task<IActionResult> CreateAsync(T request);
}
