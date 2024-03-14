using ITIExaminationSyustem.Interfaces;
using ITIExaminationSyustem.Models;
using ITIExaminationSyustem.ViewModels;
using ITIExaminationSyustem.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace ITIExaminationSyustem.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        private IStudentRepo _studentRepo;
        private IDepartmentRepo _departmentRepo;
        private IMainDeptRepo _mainDeptRepo;
        private ICourseRepo _courseRepo;
        private IStudentCourseRepo _studentCourseRepo;
        private IUserRepo _userRepo;
        private IBranchRepo _branchRepo;
        private Exam_Context _context;
        public StudentController(IBranchRepo branchRepo,IStudentRepo studentRepo, IDepartmentRepo departmentRepo, IMainDeptRepo mainDeptRepo, ICourseRepo courseRepo, IStudentCourseRepo studentCourseRepo, Exam_Context context, IUserRepo userRepo)
        {
            _studentRepo = studentRepo;
            _departmentRepo = departmentRepo;
            _mainDeptRepo = mainDeptRepo;
            _courseRepo = courseRepo;
            _studentCourseRepo = studentCourseRepo;
            _context = context;
            _userRepo= userRepo;
            _branchRepo = branchRepo;
        }
        public IActionResult Index()
        {
            var StudentList = _studentRepo.GetAll();
            
            return View(StudentList);
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            else
            {
                Student student = _studentRepo.GetById(id.Value);
                if (student == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(student);
                }
            }
        }

        public IActionResult StudentCourses(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            else
            {
                Student student = _studentRepo.GetById(id.Value);
                if (student == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(student);
                }
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            StudentDepartmentsViewModel studentdepartment= new StudentDepartmentsViewModel();
            var student = _studentRepo.GetById(id);
            
           
            var allCoursesInStudentDepartment = _departmentRepo.GetCourses(student.Dept_Id.Value);
            
            //department

            var branchId = student.Navigation_Department.Brch_Id;
           
            var departmentsInBranch = _departmentRepo.GetDepartmentsByBranchId(branchId.Value);


            studentdepartment.MainDepartmentsInStudentBranch = departmentsInBranch.Select(a=>a.Navigation_MainDepartment).ToList();

        //-----------------------------------------------------------------------------------------------------------------------------------
            studentdepartment.Student_Name = student.Navigation_User?.User_Name;
            studentdepartment.Student_Email = student.Navigation_User?.User_Email;
            studentdepartment.Student_DepartmentName = student.Navigation_Department?.Navigation_MainDepartment?.MainDepartment_Name;
            studentdepartment.StudentCourses = _studentCourseRepo.GetStudentCourses(id);
            studentdepartment.Student_Image = student.Navigation_User?.User_Image;
            ViewBag.CoursesNotInStudent = allCoursesInStudentDepartment.Except(studentdepartment.StudentCourses);
            return View(studentdepartment);
        }

        [HttpPost]
        async public Task<IActionResult> Edit(int id,IFormFile image,List<int> toAdd, List<int> toRemove, StudentDepartmentsViewModel studentDepartmentsViewModel)
        {
            if (ModelState.IsValid)
            {
                var student = _studentRepo.GetById(id);
                // handle courses
                foreach (var item in toAdd)
                {
                    var studentCourse = new StudentCourse {Std_Id=id,Crs_Id=item,Bouns=0 };
                    student.Navigation_StudentCourses.Add(studentCourse);
                }
                _context.SaveChanges();
                foreach (var item in toRemove)
                {
                    var studentCourse = _studentCourseRepo.GetStudentCourseDetails(id, item);
                    student.Navigation_StudentCourses.Remove(studentCourse);
                }
                _context.SaveChanges();
                // handle department
                var branchId = student.Navigation_Department.Brch_Id;
                var mainDepartmentId = studentDepartmentsViewModel.Student_DepartmentNumber; //main dep
                var newDepartment = _departmentRepo.GetDepartmentsByBranchId(branchId.Value).FirstOrDefault(a => a.MainDept_Id == mainDepartmentId);
                student.Dept_Id = newDepartment.Department_Id;
                _context.SaveChanges();
                //--------------------------------------------------
                student.Navigation_User.User_Email = studentDepartmentsViewModel.Student_Email;
                student.Navigation_User.User_Name = studentDepartmentsViewModel.Student_Name;
                _context.SaveChanges();
                //update image
                if (image != null)
                {
                    string fileExt = image.FileName.Split('.').Last();
                    string imagePath = $"wwwroot/Images/img-{student.Student_Id}.{fileExt}";
                    using (var fs = new FileStream(imagePath, FileMode.Create)) // make this line used inside the brackets and then disposed
                    {
                        await image.CopyToAsync(fs);
                    }
                    student.Navigation_User.User_Image = $"/Images/img-{student.Student_Id}.{fileExt}";
                    _context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            else
            {
                string errorMessage = "";
                foreach (var modelStateValue in ModelState.Values)
                {
                    foreach (var error in modelStateValue.Errors)
                    {
                        // Log or debug the error messages
                        errorMessage += error.ErrorMessage;
                    }
                }
                ViewBag.errs = errorMessage;
                return View(studentDepartmentsViewModel);

            }


        }

        //public IActionResult getUsers()
        //{
        //    var departments = _departmentRepo.GetAll();
        //    ViewBag.Users = _userRepo.GetNonAssignedUsers();
        //    return View(departments);
        //}
        [HttpGet]
        public IActionResult Add() // user
        {
            ViewBag.Users = _userRepo.GetNonAssignedUsers();
            var branches = _branchRepo.GetAll();
            return View(branches);

        }
        [HttpGet]
        public IActionResult AddToBranch(int branchId,int userId) // branch id
        {
            var mainDepartments = _departmentRepo.GetDepartmentsByBranchId(branchId).Select(a=>a.Navigation_MainDepartment).ToList();
            TempData["BranchId"] = branchId;
            TempData["UserId"] = userId;
            return View(mainDepartments);
        }
        [HttpPost]
        public IActionResult AddToBranch(AddStudentViewModel addStudentViewModel)
        {
            int branchId;
            int userId;
            
                branchId = (int)TempData["BranchId"];
            userId = (int)TempData["UserId"];
            var department = _departmentRepo.GetDepartmentsByBranchId(branchId).SingleOrDefault(a=>a.MainDept_Id== addStudentViewModel.Department_Id);
            var Student = new Student { Dept_Id = department.Department_Id, Std_User_Id = userId };
            _studentRepo.Add(Student);
            var studentCourses = _departmentRepo.GetByBranchAndMainDepartment(branchId, addStudentViewModel.Department_Id).Navigation_Courses.ToList();
            addStudentViewModel.StudentCourses = studentCourses;
            addStudentViewModel.Student_Id = Student.Student_Id;
            _studentRepo.AddRole(Student.Student_Id);
            return View("AddCourses", addStudentViewModel);
        }

        [HttpPost]
        public IActionResult AddCourses(int id,List<int> StudentCoursesId) {
            foreach(var item in StudentCoursesId)
            {
                _studentCourseRepo.Add(id,item);
            }
            return RedirectToAction("Index");
        }
    }
}
