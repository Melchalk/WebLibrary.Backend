namespace WebLibrary.Commands.Common_interfaces;

public interface IDeleteCommand<T, U>
{
    Task<U> DeleteAsync(T request);
}