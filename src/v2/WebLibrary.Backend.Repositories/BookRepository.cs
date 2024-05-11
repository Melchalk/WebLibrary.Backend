﻿using DbModels;
using Microsoft.EntityFrameworkCore;
using StructureOfUniversity.PostgreSql.Ef.Interfaces;
using System.Reflection;
using WebLibrary.Backend.Provider.Repositories.Interfaces;

namespace WebLibrary.Backend.Provider.Repositories;

public class BookRepository : IBookRepository
{
    private readonly IDataProvider _provider;

    public BookRepository(IDataProvider provider)
    {
        _provider = provider;
    }

    public async Task AddAsync(DbBook book)
    {
        _provider.Books.Add(book);

        await _provider.SaveAsync();
    }

    public async Task<DbBook?> GetAsync(Guid bookId)
    {
        return await _provider.Books
            .FirstOrDefaultAsync(u => u.Id == bookId);
    }

    public DbSet<DbBook> Get()
    {
        return _provider.Books;
    }

    public async Task UpdateAsync(DbBook book)
    {
        DbBook? oldBook = await GetAsync(book.Id);

        foreach (PropertyInfo property in typeof(DbBook).GetProperties())
        {
            property?.SetValue(oldBook, property.GetValue(book));
        }

        await _provider.SaveAsync();
    }

    public async Task DeleteAsync(DbBook book)
    {
        _provider.Books.Remove(book);

        await _provider.SaveAsync();
    }
}