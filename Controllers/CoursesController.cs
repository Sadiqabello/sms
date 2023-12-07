using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SMS.Data;
using SMS.Data.Entities;



namespace SMS.Controllers;

public class CoursesController : Controller
{
    private readonly AppDbContext _appDbContext;
    public CoursesController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public IActionResult Index()
    {
        List<Course> courses = _appDbContext.Courses.ToList();
        return View(courses);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Course course)
    {
        if (ModelState.IsValid)
        {
            _appDbContext.Courses.Add(course);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index", "Courses");
        }
        else
        {
            return View(course);
        }
    }

    
    public IActionResult Edit(int id)
    {
        Course? course = _appDbContext.Courses.Find(id);

        if (course == null)
        {
            return NotFound();
        }

        return View(course);
    }

    [HttpPost]
    public IActionResult Edit(Course course)
    {
        if (ModelState.IsValid)
        {
            _appDbContext.Courses.Update(course);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return View(course);
        }
    }

    // Delete
    public IActionResult Delete(int id)
    {
        Course? course = _appDbContext.Courses.Find(id);

        if (course == null)
        {
            return NotFound();
        }

        _appDbContext.Courses.Remove(course);
        _appDbContext.SaveChanges();

        return RedirectToAction("Index");
    }
}

