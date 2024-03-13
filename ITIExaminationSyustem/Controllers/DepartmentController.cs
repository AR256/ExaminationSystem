//using AspNetCore;
using ITIExaminationSyustem.Interfaces;
using ITIExaminationSyustem.Models;
using ITIExaminationSyustem.Repositories;
using ITIExaminationSyustem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITIExaminationSyustem.Controllers
{
    [Authorize]
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
            if (id == null)
            {
                return BadRequest();
            }
            else
            {
                Department fetchedDepartment = _departmentRepo.GetById(id.Value);
                if (fetchedDepartment == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(fetchedDepartment);
                }
            }
        }

        public IActionResult DisplayStudents(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            else
            {
                Department fetchedDepartment = _departmentRepo.GetById(id.Value);
                if (fetchedDepartment == null)
                {
                    return NotFound();
                }
                else
                {
                    List<Student> students = _studentRepo.GetAll().Where(std => std.Dept_Id == id.Value).ToList();
                    return View(students);
                }
            }
        }

        public IActionResult DisplayInstructors(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            else
            {
                Department fetchedDepartment = _departmentRepo.GetById(id.Value);
                if (fetchedDepartment == null)
                {
                    return NotFound();
                }
                else
                {
                    List<DepartmentInstructors> deptInstructors = _departmentRepo.GetById(id.Value).Navigation_Department_Instructor.ToList();
                    return View(deptInstructors);
                }
            }
        }

        public IActionResult DisplayCourses(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            else
            {
                Department fetchedDepartment = _departmentRepo.GetById(id.Value);
                if (fetchedDepartment == null)
                {
                    return NotFound();
                }
                else
                {
                    List<Course> courses = _departmentRepo.GetCourses(id.Value).ToList();
                    return View(courses);
                }
            }
        }

        public IActionResult Create()
        {
            DepartmentViewModel departmentViewModel = new();
            departmentViewModel.branches = _branchRepo.GetAll();
            departmentViewModel.mainDepartments = _mainDeptRepo.GetAll();
            departmentViewModel.instructors = _instructorRepo.GetAll();
            return View(departmentViewModel);
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
            if (id == null)
            {
                return BadRequest();
            }
            else
            {
                Department fetchedDepartment = _departmentRepo.GetById(id.Value);
                if(fetchedDepartment == null)
                {
                    return NotFound();
                }
                else
                {
                    DepartmentViewModel departmentViewModel = PrepareViewModel(id.Value);
                    return View(departmentViewModel);
                }
            }
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

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            else
            {
                Department fetchedDepartment = _departmentRepo.GetById(id.Value);
                if (fetchedDepartment == null)
                {
                    return NotFound();
                }
                else
                {
                    bool result = _departmentRepo.Delete(id.Value);
                    if (result)
                        return RedirectToAction("Index");
                    else
                        return RedirectToAction("Index");
                }
            }
        }

        public DepartmentViewModel PrepareViewModel(int id)
        {
            Department department = _departmentRepo.GetById(id);
            DepartmentViewModel departmentViewModel = new();

            departmentViewModel.Department_Id = department.Department_Id;
            departmentViewModel.Department_Name = department.Department_Name;
            departmentViewModel.Department_MgrId = department.Department_MgrId;
            departmentViewModel.Brch_Id = department.Brch_Id;
            departmentViewModel.MainDept_Id = department.MainDept_Id;
            departmentViewModel.branches = _branchRepo.GetAll();
            departmentViewModel.mainDepartments = _mainDeptRepo.GetAll();
            departmentViewModel.instructors = _instructorRepo.GetAll();

            return departmentViewModel;
        }
    }
}
