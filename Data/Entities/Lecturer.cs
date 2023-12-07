using System;
using System.ComponentModel.DataAnnotations;

namespace SMS.Data.Entities;

public class Lecturer
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;
}

