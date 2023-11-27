using Microsoft.AspNetCore.Mvc;

namespace WebLibrary.Commands.Common_interfaces;

public interface IUpdater<T>
{
    Task<IActionResult> UpdateAsync(Guid id, T request);
}
