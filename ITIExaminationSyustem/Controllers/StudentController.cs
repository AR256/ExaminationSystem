using ITIExaminationSyustem.Interfaces;
using ITIExaminationSyustem.Models;
using ITIExaminationSyustem.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ITIExaminationSyustem.Controllers
{
    public class StudentController : Controller
    {
        private IStudentRepo _studentRepo;
        private IDepartmentRepo _departmentRepo;
        public StudentController(IStudentRepo studentRepo, IDepartmentRepo departmentRepo)
        {
            _studentRepo = studentRepo;
            _departmentRepo = departmentRepo;
        }
        public IActionResult Index()
        {
            var StudentList = _studentRepo.GetAll();
            
            return View(StudentList);
        }
        public IActionResult Details(int id)
        {
            var std = _studentRepo.GetById(id);
            return View(std);
        }
        //[HttpGet]
        //public IActionResult Edit(int id)
        //{
        //    //var departmentList=

        //    //var student = _studentRepo.GetById(id);
        //    //return View(student);
        //}

    }
}
