using System.ComponentModel.DataAnnotations;

namespace SMS.Data.Entities;

public class Course
{
    //public Course()
    //{
    //}

    public int Id { get; set; }
    
    public string CourseTitle { get; set; } = string.Empty;

    public string CourseCode { get; set; } = string.Empty;

    public int CreditUnit { get; set; }

    public string? CourseDescription { get; set; }
}