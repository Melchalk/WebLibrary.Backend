using Microsoft.EntityFrameworkCore;
using System.Reflection;
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

    public async Task AddAsync(DbHall hall)
    {
        _provider.Halls.Add(hall);

        await _provider.SaveAsync();
    }

    public async Task<DbHall?> GetAsync(Guid libraryId, uint number)
    {
        return await _provider.Halls
            .FirstOrDefaultAsync(u => u.LibraryId == libraryId && u.Number == number);
    }

    public DbSet<DbHall> Get()
    {
        return _provider.Halls;
    }

    public async Task UpdateAsync(DbHall hall)
    {
        DbHall? oldHall = await GetAsync(hall.LibraryId, hall.Number);

        foreach (PropertyInfo property in typeof(DbHall).GetProperties())
        {
            property?.SetValue(oldHall, property.GetValue(hall));
        }

        await _provider.SaveAsync();
    }

    public async Task DeleteAsync(DbHall hall)
    {
        _provider.Halls.Remove(hall);

        await _provider.SaveAsync();
    }
}