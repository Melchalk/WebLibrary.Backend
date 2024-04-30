namespace WebLibrary.Commands.Common_interfaces;

public interface IUpdateCommand<T, U>
{
    Task<U> UpdateAsync(T request);
}