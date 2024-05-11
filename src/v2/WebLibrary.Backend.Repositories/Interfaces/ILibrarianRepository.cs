using Microsoft.EntityFrameworkCore;
using WebLibrary.Backend.Models.Db;

namespace WebLibrary.Backend.Repositories.Interfaces;

public interface ILibrarianRepository
{
    Task AddAsync(DbLibrarian entity);

    Task<DbLibrarian?> GetAsync(Guid id);

    DbSet<DbLibrarian> Get();

    Task UpdateAsync(DbLibrarian entity);

    Task DeleteAsync(DbLibrarian entity);
}
