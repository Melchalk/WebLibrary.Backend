﻿using WebLibrary.Backend.Models.DTO.Responses.Hall;
using WebLibrary.Backend.Models.DTO.Responses.Librarian;

namespace WebLibrary.Backend.Models.DTO.Responses.Library;

public class GetLibraryResponse
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Address { get; set; }
    public required string Phone { get; set; }

    public required IList<GetLibrarianResponse> Librarians { get; set; }
    public required IList<GetHallResponse> Halls { get; set; }
}