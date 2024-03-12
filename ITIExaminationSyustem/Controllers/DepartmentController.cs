//using AspNetCore;
using ITIExaminationSyustem.Interfaces;
using ITIExaminationSyustem.Models;
using ITIExaminationSyustem.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ITIExaminationSyustem.Controllers
{
    public class DepartmentController : Controller
    {
        IDepartmentRepo _departmentRepo;
        IStudentRepo _studentRepo;
        IInstructorRepo _instructorRepo;
        ICourseRepo _courseRepo;
        IBranchRepo _branchRepo;
        IMainDeptRepo _mainDeptRepo;

        public DepartmentController(IDepartmentRepo departmentRepo, IStudentRepo studentRepo, IInstructorRepo instructorRepo, ICourseRepo courseRepo, IBranchRepo branchRepo, IMainDeptRepo mainDeptRepo)
        {
            _departmentRepo = departmentRepo;
            _studentRepo = studentRepo;
            _instructorRepo = instructorRepo;
            _courseRepo = courseRepo;
            _branchRepo = branchRepo;
            _mainDeptRepo = mainDeptRepo;
        }

        public IActionResult Index()
        {
            List<Department> departments = _departmentRepo.GetAll();
            return View(departments);
        }

        public IActionResult Details(int? id)
        {
            Department department = _departmentRepo.GetById(id.Value);

            return View(department);
        }


        public IActionResult DisplayStudents(int? id)
        {
            List<Student> students = _studentRepo.GetAll().Where(std => std.Dept_Id == id.Value).ToList();
            return View(students);
        }

        public IActionResult Create()
        {
            List<Branch> branches = _branchRepo.GetAll();
            List<MainDepartment> mainDepartments = _mainDeptRepo.GetAll();
            ViewBag.Branches = branches;
            ViewBag.MainDepartments = mainDepartments;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department department) 
        {
            if (ModelState.IsValid)
            {
                _departmentRepo.Add(department);
                return RedirectToAction("Index");
            }
            else
            {
                return View(department);
            }
        }

        public IActionResult Edit(int? id)
        {
            Department department = _departmentRepo.GetById(id.Value);
            List<Branch> branches = _branchRepo.GetAll();
            List<MainDepartment> mainDepartments = _mainDeptRepo.GetAll();
            ViewBag.Branches = branches;
            ViewBag.MainDepartments = mainDepartments;
            return View(department);
        }

        [HttpPost]
        public IActionResult Edit(Department department, int id)
        {
            department.Department_Id = id;
            if (ModelState.IsValid)
            {
                _departmentRepo.Update(department);
                return RedirectToAction("Index");
            }
            else
            {
                return View(department);
            }
        }

        public IActionResult Delete(int id)
        {
            _departmentRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
