using System;
using SMS.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace SMS.Models;

public class CourseVM
{
    public int? Id { get; set; }
    [Required]
    public string CourseTitle { get; set; } = string.Empty;
    [Required]
    public string CourseCode { get; set; } = string.Empty;
    [Required]
    public int CreditUnit { get; set; }
    [Required]
    public string? CourseDescription { get; set; }
}

