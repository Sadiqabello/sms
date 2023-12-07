using System;
using SMS.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace SMS.Models;

public class StudentVM
{
    public int? Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string RegNo { get; set; } = string.Empty;
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
}

