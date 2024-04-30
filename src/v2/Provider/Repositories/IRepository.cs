using Microsoft.EntityFrameworkCore;

namespace Provider.Repositories;

public interface IRepository<T, U> where T : class
{
    Task<T?> GetAsync(U primaryKey);

    DbSet<T> Get();

    Task<T> UpdateAsync(T entity);

    Task DeleteAsync(T entity);
}