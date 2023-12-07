using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SMS.Data;
using SMS.Data.Entities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SMS.Controllers;

public class LecturersController : Controller
{
    private readonly AppDbContext _appDbContext;
    public LecturersController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public IActionResult Index()
    {
        List<Lecturer> lecturers = _appDbContext.Lecturers.ToList();

        return View(lecturers);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Lecturer lecturer)
    {
        if (ModelState.IsValid)
        {
            //TODO: Add to Database
            _appDbContext.Lecturers.Add(lecturer);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index", "Lecturers");
        }
        else
        {
            return View(lecturer);
        }
    }

    //EDIT
    public IActionResult Edit(int id)
    {
        Lecturer? lecturer = _appDbContext.Lecturers.Find(id);

        if (lecturer == null)
        {
            return NotFound();
        }

        return View(lecturer);
    }

    [HttpPost]
    public IActionResult Edit(Lecturer lecturer)
    {
        if (ModelState.IsValid)
        {
            _appDbContext.Lecturers.Update(lecturer);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return View(lecturer);
        }
    }

    // Delete
    [HttpPost]
    public IActionResult Delete(int id)
    {
        Lecturer? lecturer = _appDbContext.Lecturers.Find(id);

        if (lecturer == null)
        {
            return NotFound();
        }

        _appDbContext.Lecturers.Remove(lecturer);
        _appDbContext.SaveChanges();

        return RedirectToAction("Index");
    }
}

