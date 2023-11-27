using DbModels;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Provider.Repositories.Hall;

public class HallRepository : IHallRepository
{
    private readonly OfficeDbContext _context = new();

    public async Task AddAsync(DbHall hall)
    {
        _context.Halls.Add(hall);

        await _context.SaveChangesAsync();
    }

    public async Task<DbHall?> GetAsync(Guid hallId)
    {
        return await _context.Halls.FirstOrDefaultAsync(u => u.Id == hallId);
    }

    public DbSet<DbHall> Get()
    {
        return _context.Halls;
    }

    public async Task<DbHall?> UpdateAsync(DbHall? hall)
    {
        DbHall? oldHall = GetAsync(hall.Id).Result;

        if (oldHall is null)
        {
            return null;
        }

        foreach (PropertyInfo property in typeof(DbHall).GetProperties())
        {
            property?.SetValue(oldHall, property.GetValue(hall));
        }

        await _context.SaveChangesAsync();

        return GetAsync(hall.Id).Result;
    }

    public async Task DeleteAsync(DbHall hall)
    {
        _context.Halls.Remove(hall);

        await _context.SaveChangesAsync();
    }
}