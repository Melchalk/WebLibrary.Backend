﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebLibrary.Backend.Models.Db;
using WebLibrary.Backend.Models.DTO.Requests.Book;
using WebLibrary.Backend.Models.DTO.Responses.Book;
using WebLibrary.Backend.Models.Exceptions;
using WebLibrary.Backend.Repositories.Interfaces;
using WebLibraryService.Backend.Domain.Interfaces;

namespace WebLibraryService.Backend.Domain;

public class BookService : IBookService
{
    private readonly IBookRepository _repository;
    private readonly IMapper _mapper;

    public BookService(
        IBookRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Guid> CreateAsync(CreateBookRequest request, CancellationToken token)
    {
        var book = _mapper.Map<DbBook>(request);

        await _repository.AddAsync(book, token);

        return book.Id;
    }

    public async Task<List<GetBookResponse>> GetAllAsync(int libraryNumber, CancellationToken token)
    {
        return await _mapper.ProjectTo<GetBookResponse>(
            _repository.Get().Where(b => b.LibraryNumber == libraryNumber))
            .ToListAsync(token);
    }

    public async Task<List<GetBookResponse>> GetFreeAsync(int libraryNumber, CancellationToken token)
    {
        return await _mapper.ProjectTo<GetBookResponse>(
            _repository.Get()
            .Where(b => b.LibraryNumber == libraryNumber && b.IssueId == null))
            .ToListAsync(token);
    }

    public async Task<GetBookResponse> GetAsync(Guid id, CancellationToken token)
    {
        var book = await _repository.GetAsync(id, token)
            ?? throw new BadRequestException($"Book with id = '{id}' not found.");

        return _mapper.Map<GetBookResponse>(book);
    }

    public async Task DeleteAsync(Guid id, CancellationToken token)
    {
        var book = await _repository.GetAsync(id, token)
            ?? throw new BadRequestException($"Book with id = '{id}' not found.");

        await _repository.DeleteAsync(book, token);
    }

    public async Task UpdateAsync(UpdateBookRequest request, CancellationToken token)
    {
        var book = await _repository.GetAsync(request.Id, token)
            ?? throw new BadRequestException($"Book with id = '{request.Id}' not found.");

        book.Title = request.Title ?? book.Title;
        book.Author = request.Author ?? book.Author;
        book.NumberPages = request.NumberPages ?? book.NumberPages;
        book.YearPublishing = request.YearPublishing ?? book.YearPublishing;
        book.CityPublishing = request.CityPublishing ?? book.CityPublishing;

        await _repository.SaveAsync(token);
    }
}
