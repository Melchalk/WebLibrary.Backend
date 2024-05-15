using Microsoft.EntityFrameworkCore;
using WebLibrary.Backend.Models.Db;
using WebLibrary.Backend.Provider.Interfaces;
using WebLibrary.Backend.Repositories.Interfaces;

namespace WebLibrary.Backend.Repositories;

public class HallRepository : IHallRepository
{
    private readonly IDataProvider _provider;

    public HallRepository(IDataProvider provider)
    {
        _provider = provider;
    }

    public async Task AddAsync(DbHall hall, CancellationToken token)
    {
        await _provider.Halls.AddAsync(hall, token);

        await _provider.SaveAsync(token);
    }

    public async Task<DbHall?> GetAsync(int libraryNumber, uint number, CancellationToken token)
    {
        return await _provider.Halls
            .FirstOrDefaultAsync(u => u.LibraryNumber == libraryNumber && u.Number == number, token);
    }

    public async Task DeleteAsync(DbHall hall, CancellationToken token)
    {
        _provider.Halls.Remove(hall);

        await _provider.SaveAsync(token);
    }

    public DbSet<DbHall> Get() => _provider.Halls;

    public async Task SaveAsync(CancellationToken token) => await _provider.SaveAsync(token);
}