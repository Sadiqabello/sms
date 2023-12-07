using Microsoft.AspNetCore.Mvc;
using SMS.Data;
using SMS.Data.Entities;

namespace SMS.Controllers;

public class StudentsController : Controller
{
    private readonly AppDbContext _appDbContext;
    public StudentsController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public IActionResult Index()
    {
        List<Student> students = _appDbContext.Students.ToList();

        return View(students);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Student student)
    {
        if (ModelState.IsValid)
        {
            //TODO: Add to Database
            _appDbContext.Students.Add(student);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index", "Students");
        }
        else
        {
            return View(student);
        }
    }

    //EDIT
    
    public IActionResult Edit(int id)
    {
        Student? student = _appDbContext.Students.Find(id);

        if (student == null)
        {
            return NotFound();
        }

        return View(student);
    }

    [HttpPost]
    public IActionResult Edit(Student student)
    {
        if (ModelState.IsValid)
        {
            _appDbContext.Students.Update(student);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return View(student);
        }
    }

    // Delete
    public IActionResult Delete(int id)
    {
        Student? student = _appDbContext.Students.Find(id);

        if (student == null)
        {
            return NotFound();
        }

        _appDbContext.Students.Remove(student);
        _appDbContext.SaveChanges();

        return RedirectToAction("Index");
    }

}
