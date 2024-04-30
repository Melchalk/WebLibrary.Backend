namespace WebLibrary.Commands.Common_interfaces;

public interface IUpdatCommand<T, U>
{
    Task<U> UpdateAsync(T request);
}