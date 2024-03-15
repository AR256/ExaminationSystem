using ITIExaminationSyustem.Interfaces;
using ITIExaminationSyustem.Models;
using ITIExaminationSyustem.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITIExaminationSyustem.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        ICourseRepo _courseRepo;
        public CourseController(ICourseRepo courseRepo)
        {
            _courseRepo = courseRepo;
        }
        public IActionResult Index()
        {
            var model = _courseRepo.GetAll();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Course model)
        {
            var m = _courseRepo.GetById(model.Course_Id);
            if (ModelState.IsValid && m == null)
            {
                _courseRepo.Add(model);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return BadRequest();
            var model = _courseRepo.GetById(id.Value);
            if (model == null)
                return NotFound();
            return View(model);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
                return BadRequest();
            var model = _courseRepo.GetById(id.Value);
            if (model == null)
                return NotFound();
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(Course course, int id)
        {
            if (ModelState.IsValid)
            {
                course.Course_Id = id;
                _courseRepo.Update(course);
                return RedirectToAction("Index");
            }
            return View(course);

        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return BadRequest();
            _courseRepo.Delete(id.Value);
            return RedirectToAction("Index");
        }
    }
}
