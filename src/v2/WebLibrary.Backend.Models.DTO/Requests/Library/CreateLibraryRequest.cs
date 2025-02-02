﻿using System.ComponentModel.DataAnnotations;

namespace WebLibrary.Backend.Models.DTO.Requests.Library;

public class CreateLibraryRequest
{
    [MaxLength(50)]
    public required string Title { get; set; }

    [MaxLength(50)]
    public required string Address { get; set; }

    [MaxLength(50)]
    public required string Phone { get; set; }
}