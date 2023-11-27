using Microsoft.EntityFrameworkCore;

namespace Provider.Repositories;

public interface IRepository<T> where T : class
{
    Task AddAsync(T entity);

    Task<T?> GetAsync(Guid id);

    DbSet<T> Get();

    Task<T> UpdateAsync(T entity);

    Task DeleteAsync(T entity);
}