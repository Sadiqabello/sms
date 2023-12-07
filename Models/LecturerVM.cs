using System;
using System.ComponentModel.DataAnnotations;
using SMS.Data.Entities;
namespace SMS.Models;

public class LecturerVM
{
    public int? Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
}

