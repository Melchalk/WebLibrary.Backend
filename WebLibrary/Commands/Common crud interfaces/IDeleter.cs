using Microsoft.AspNetCore.Mvc;

namespace WebLibrary.Commands.Common_interfaces;

public interface IDeleter
{
    Task<IActionResult> DeleteAsync(Guid id);
}
