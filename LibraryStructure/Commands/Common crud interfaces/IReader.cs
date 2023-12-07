namespace WebLibrary.Commands.Common_interfaces;

public interface IReader<T, U, K>
{
    Task<U> GetAsync(T request);

    K Get();
}