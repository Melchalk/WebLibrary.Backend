namespace WebLibrary.Commands.Common_interfaces;

public interface IReadCommand<T, U, K>
{
    Task<U> GetAsync(T request);

    K Get();
}