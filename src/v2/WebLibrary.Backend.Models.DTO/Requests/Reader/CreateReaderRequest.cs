﻿using System.ComponentModel.DataAnnotations;

namespace WebLibrary.Backend.Models.DTO.Requests.Reader;

public class CreateReaderRequest
{
    [MaxLength(50)]
    public required string FullName { get; set; }

    [MaxLength(50)]
    public required string Phone { get; set; }

    [MaxLength(50)]
    public string? RegistrationAddress { get; set; }

    [Range(14, 100, ErrorMessage = "The age must be over 14")]
    public uint Age { get; set; }
    public bool CanTakeBooks { get => Age >= 18 && RegistrationAddress != null; }
}