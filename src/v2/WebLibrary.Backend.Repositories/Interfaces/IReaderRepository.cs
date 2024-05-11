using Microsoft.EntityFrameworkCore;
using WebLibrary.Backend.Models.Db;

namespace WebLibrary.Backend.Repositories.Interfaces;

public interface IReaderRepository
{
    Task AddAsync(DbReader entity);

    Task<DbReader?> GetAsync(Guid id);

    DbSet<DbReader> Get();

    Task UpdateAsync(DbReader entity);

    Task DeleteAsync(DbReader entity);
}