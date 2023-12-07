namespace WebLibrary.Commands.Common_interfaces;

public interface ICreater<T, U>
{
    Task<U> CreateAsync(T request);
}