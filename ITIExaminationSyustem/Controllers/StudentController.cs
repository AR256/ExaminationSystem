using ITIExaminationSyustem.Interfaces;
using ITIExaminationSyustem.Models;
using ITIExaminationSyustem.ViewModels;
using ITIExaminationSyustem.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ITIExaminationSyustem.Controllers
{
    public class StudentController : Controller
    {
        private IStudentRepo _studentRepo;
        private IDepartmentRepo _departmentRepo;
        private IMainDeptRepo _mainDeptRepo;
        private ICourseRepo _courseRepo;
        private IStudentCourseRepo _studentCourseRepo;
        public StudentController(IStudentRepo studentRepo, IDepartmentRepo departmentRepo, IMainDeptRepo mainDeptRepo, ICourseRepo courseRepo, IStudentCourseRepo studentCourseRepo)
        {
            _studentRepo = studentRepo;
            _departmentRepo = departmentRepo;
            _mainDeptRepo = mainDeptRepo;
            _courseRepo = courseRepo;
            _studentCourseRepo = studentCourseRepo;
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
        [HttpGet]
        public IActionResult Edit(int id)
        {
            StudentDepartmentsViewModel studentdepartment= new StudentDepartmentsViewModel();
            var allCourses=_courseRepo.GetAll();
            

            studentdepartment.MainDepartments = _mainDeptRepo.GetAll();          
            var student = _studentRepo.GetById(id);
            studentdepartment.Student_Name = student.Navigation_User.User_Name;
            studentdepartment.Student_Email = student.Navigation_User.User_Email;
            studentdepartment.Student_DepartmentName = student.Navigation_Department.Navigation_MainDepartment.MainDepartment_Name;
            studentdepartment.StudentCourses = _studentCourseRepo.GetStudentCourses(id);
            studentdepartment.Student_Image = student.Navigation_User.User_Image;
            ViewBag.CoursesNotInStudent = allCourses.Except(studentdepartment.StudentCourses);
            return View(studentdepartment);
        }
        [HttpPost]
        public IActionResult Edit(int id,IFormFile image,List<int> toAdd, List<int> toRemove,int departmentNumber,int Email,string Name)
        {
            var student =_studentRepo.GetById(id);
            foreach(var item in toAdd)
            {
                var course = _courseRepo.GetById(item);
                student.Navigation_StudentCourses.Add(course);
            }
        }
        

    }
}
