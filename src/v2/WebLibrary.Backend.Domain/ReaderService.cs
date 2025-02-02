﻿using AutoMapper;
using Azure;
using Microsoft.EntityFrameworkCore;
using WebLibrary.Backend.Models.Db;
using WebLibrary.Backend.Models.DTO.Requests.Reader;
using WebLibrary.Backend.Models.DTO.Responses.Reader;
using WebLibrary.Backend.Models.Exceptions;
using WebLibrary.Backend.Repositories.Interfaces;
using WebLibraryService.Backend.Domain.Interfaces;

namespace WebLibraryService.Backend.Domain;

public class ReaderService : IReaderService
{
    private readonly IReaderRepository _repository;
    private readonly IMapper _mapper;

    public ReaderService(
        IReaderRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Guid> CreateAsync(CreateReaderRequest request, CancellationToken token)
    {
        var reader = _mapper.Map<DbReader>(request);

        await _repository.AddAsync(reader, token);

        return reader.Id;
    }

    public async Task<List<GetReaderResponse>> GetAllAsync(CancellationToken token)
    {
        return await _mapper.ProjectTo<GetReaderResponse>(
            _repository.Get())
            .ToListAsync(token);
    }

    public async Task<GetReaderResponse> GetAsync(Guid id, CancellationToken token)
    {
        var reader = await _repository.GetAsync(id, token)
            ?? throw new BadRequestException($"Reader with id = '{id}' not found.");

        return _mapper.Map<GetReaderResponse>(reader);
    }

    public async Task DeleteAsync(Guid id, CancellationToken token)
    {
        var reader = await _repository.GetAsync(id, token)
            ?? throw new BadRequestException($"Reader with id = '{id}' not found.");

        await _repository.DeleteAsync(reader, token);
    }

    public async Task UpdateAsync(UpdateReaderRequest request, CancellationToken token)
    {
        var reader = await _repository.GetAsync(request.Id, token)
            ?? throw new BadRequestException($"Reader with id = '{request.Id}' not found.");

        reader.FullName = request.FullName ?? reader.FullName;
        reader.Phone = request.Phone ?? reader.Phone;
        reader.RegistrationAddress = request.RegistrationAddress ?? reader.RegistrationAddress;
        reader.Age = request.Age ?? reader.Age;

        reader.CanTakeBooks = reader.Age >= 18 && reader.RegistrationAddress != null;

        await _repository.SaveAsync(token);
    }
}
