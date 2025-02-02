﻿using System.ComponentModel.DataAnnotations;

namespace WebLibrary.Backend.Models.DTO.Requests.Library;

public class UpdateLibraryRequest
{
    public int Number { get; set; }

    [MaxLength(50)]
    public string? Title { get; set; }

    [MaxLength(50)]
    public string? Address { get; set; }

    [MaxLength(50)]
    public string? Phone { get; set; }
}