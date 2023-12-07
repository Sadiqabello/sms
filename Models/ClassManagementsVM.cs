using System;
using SMS.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.Models;

public class ClassManagementsVM
{
    public int? Id { get; set; }

    public int LecturerId { get; set; }

    public int CourseId { get; set; }
}

