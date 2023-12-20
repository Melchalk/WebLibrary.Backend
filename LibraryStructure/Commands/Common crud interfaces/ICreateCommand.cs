namespace WebLibrary.Commands.Common_interfaces;

public interface ICreateCommand<T, U>
{
    Task<U> CreateAsync(T request);
}