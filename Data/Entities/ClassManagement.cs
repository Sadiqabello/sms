using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SMS.Data.Entities;

namespace SMS.Data.Entities;

public class ClassManagement
{
    public int Id { get; set; }

    public int LecturerId { get; set; }
    [ForeignKey(nameof(LecturerId))]
    public Lecturer? Lecturer { get; set; }
    
    public int CourseId { get; set; }
    [ForeignKey(nameof(CourseId))]
    public Course? Course { get; set; }

}

