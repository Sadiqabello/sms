using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SMS.Data;
using SMS.Data.Entities;

namespace SMS.Controllers
{
    public class ClassManagementsController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public ClassManagementsController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            List<ClassManagement> classManagements = _appDbContext.ClassManagements.ToList();
            ViewBag.Lecturers = _appDbContext.Lecturers.ToList();
            ViewBag.Courses = _appDbContext.Courses.ToList();
            return View(classManagements);
        }

        [HttpPost]
        public IActionResult AddClassManagement(ClassManagement classManagement, int lecturerId, int courseId)
        {
            // Fetch lecturer and course details from the database based on the selected IDs.
            Lecturer? lecturer = _appDbContext.Lecturers.FirstOrDefault(l => l.Id == lecturerId);
            Course? course = _appDbContext.Courses.FirstOrDefault(c => c.Id == courseId);

            if (lecturer != null && course != null)
            {
                // Assign lecturer and course details to the classManagement object.
                classManagement.LecturerId = lecturer.Id;
                classManagement.CourseId = course.Id;

                // Save the classManagement object to the database.
                _appDbContext.ClassManagements.Add(classManagement);
                _appDbContext.SaveChanges();
            }

            // Redirect back to the Index action to refresh the class management list.
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            ClassManagement? classManagement = _appDbContext.ClassManagements.Find(id);

            if (classManagement == null)
            {
                return NotFound();
            }

            ViewBag.Lecturers = _appDbContext.Lecturers.ToList();
            ViewBag.Courses = _appDbContext.Courses.ToList();

            return View(classManagement);
        }

        [HttpPost]
        public IActionResult Edit(ClassManagement classManagement)
        {
            if (ModelState.IsValid)
            {
                // Fetch lecturer and course details from the database based on the selected names.
                Lecturer? lecturer = _appDbContext.Lecturers.FirstOrDefault(l => l.Id == classManagement.LecturerId);
                Course? course = _appDbContext.Courses.FirstOrDefault(c => c.Id == classManagement.CourseId);

                if (lecturer != null && course != null)
                {
                    // Assign lecturer and course details to the classManagement object.
                    classManagement.LecturerId = lecturer.Id;
                    classManagement.CourseId = course.Id;

                    // Update the classManagement object in the database.
                    _appDbContext.Entry(classManagement).State = EntityState.Modified;
                    _appDbContext.SaveChanges();

                    // Redirect back to the Index action to refresh the class management list.
                    return RedirectToAction("Index");
                }
            }

            // If ModelState is not valid, return to the edit view with the existing data.
            ViewBag.Lecturers = _appDbContext.Lecturers.ToList();
            ViewBag.Courses = _appDbContext.Courses.ToList();
            return View("Edit", classManagement);
        }


        public IActionResult Delete(int id)
        {
            ClassManagement? classManagement = _appDbContext.ClassManagements.Find(id);

            if (classManagement == null)
            {
                return NotFound();
            }

            return View(classManagement);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            ClassManagement? classManagement = _appDbContext.ClassManagements.Find(id);

            if (classManagement != null)
            {
                _appDbContext.ClassManagements.Remove(classManagement);
                _appDbContext.SaveChanges();
            }

            // Redirect back to the Index action to refresh the class management list.
            return RedirectToAction("Index");
        }
    }
}
