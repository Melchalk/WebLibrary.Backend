namespace WebLibrary.Commands.Common_interfaces;

public interface IDeleter<T, U>
{
    Task<U> DeleteAsync(T request);
}