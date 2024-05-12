﻿using WebLibrary.Backend.Models.DTO.Requests.Hall;
using WebLibrary.Backend.Models.DTO.Responses.Hall;

namespace WebLibraryService.Backend.Domain.Interfaces;

public interface IHallService
{
    Task<uint> CreateAsync(CreateHallRequest request, CancellationToken token);

    Task<GetHallResponse> GetAsync(Guid libraryId, uint number, CancellationToken token);

    Task<List<GetHallResponse>> GetAllAsync(CancellationToken token);

    Task UpdateAsync(UpdateHallRequest request, CancellationToken token);

    Task DeleteAsync(Guid libraryId, uint number, CancellationToken token);
}
