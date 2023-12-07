namespace WebLibrary.Commands.Common_interfaces;

public interface IUpdater<T, U>
{
    Task<U> UpdateAsync(T request);
}