using ITIExaminationSyustem.Interfaces;
using ITIExaminationSyustem.Models;
using ITIExaminationSyustem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITIExaminationSyustem.Controllers
{
    [Authorize]
    public class InstructorController : Controller
    {
        private IInstructorRepo _instructorRepo;
        private IBranchRepo _branchRepo;
        private IDepartmentRepo _departmentRepo;
        private IDeptInstructorRepo _deptInstructorRepo;
        private ICourseRepo _courseRepo;
        private IUserRepo _userRepo;

        public InstructorController(ICourseRepo courseRepo,
            IInstructorRepo instructorRepo,
            IBranchRepo branchRepo,
            IDepartmentRepo departmentRepo
            , IDeptInstructorRepo deptInstructorRepo
            , IUserRepo userRepo
            )
        {
            _instructorRepo = instructorRepo;
            _branchRepo = branchRepo;
            _departmentRepo = departmentRepo;
            _deptInstructorRepo = deptInstructorRepo;
            _courseRepo = courseRepo;
            _userRepo = userRepo;
        }
        public IActionResult Index()
        {
            List<InstructorViewModel> instructorViewModelList = new List<InstructorViewModel>();

            var instructors = _instructorRepo.GetAll();
            foreach (var instructor in instructors)
            {
                InstructorViewModel instructorViewModel = new InstructorViewModel();
                instructorViewModel.Instructor_Id = instructor.Instructor_Id;
                instructorViewModel.Instructor_Image = instructor.Navigation_User.User_Image;
                instructorViewModel.Instructor_Email = instructor.Navigation_User.User_Email;
                instructorViewModel.Instructor_Name = instructor.Navigation_User.User_Name;
                instructorViewModel.Instructor_User_Id = instructor.Navigation_User.User_Id;
                instructorViewModelList.Add(instructorViewModel);
            }

            return View(instructorViewModelList);
        }

        public IActionResult Details(int? id)
        {
            var instructorViewModel = PrepareInstructor(id.Value);
            if (id == null)
            {
                return BadRequest();
            }else if (!(instructorViewModel.Instructor_Id > 0))
            {
                return NotFound();
            }
            return View(instructorViewModel);
        }

        public IActionResult InstructorCourses(int? id)
        {
            if (id == null)
                return BadRequest();
            var instructor = _instructorRepo.GetById(id.Value);
            if (instructor == null)
                return NotFound();
            else
            {
                List<Course> courses = instructor.Navigation_Courses.ToList();
                return View(courses);
            }
        }

        //Edit Instructor

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }else
            {
                var instructor = PrepareInstructor(id.Value);
                if(instructor == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(instructor);

                }
            }

        }
        [HttpPost]
        async public Task<IActionResult> SubmitEdit(string Instructor_Name, string Instructor_Email, IFormFile Instructor_Image, int id)
        {

            var instructor = _instructorRepo.GetById(id);
            if (instructor == null)
            {
                return NotFound(Instructor_Name);
            }
            if (ModelState.IsValid)
            {
                //image
                if (Instructor_Image != null)
                {
                    string fileExt = Instructor_Image.FileName.Split('.').Last();
                    string imagePath = $"wwwroot/Images/img-{instructor.Navigation_User.User_Id}.{fileExt}";
                    using (var fs = new FileStream(imagePath, FileMode.Create)) // make this line used inside the brackets and then disposed
                    {
                        await Instructor_Image.CopyToAsync(fs);
                    }
                    instructor.Navigation_User.User_Image = $"/Images/img-{instructor.Navigation_User.User_Id}.{fileExt}";
                }

                instructor.Navigation_User.User_Email = Instructor_Email;
                instructor.Navigation_User.User_Name = Instructor_Name;
                _instructorRepo.Update(instructor);
                return RedirectToAction("Index");

            }

            var instructorViewModel = PrepareInstructor(id);
            return View("ManageCourses", instructorViewModel);


        }

        public IActionResult RemoveDepartmentManager(int instructorId, int departmentId)
        {
            var instructor = _instructorRepo.GetById(instructorId);
            var department = _departmentRepo.GetById(departmentId);
            if (instructor == null || department == null)
                return NotFound();
            instructor.Navigation_Departments.Remove(department);
            _instructorRepo.Update(instructor);
            var instructorViewModel = PrepareInstructor(instructorId);
            return View("Edit", instructorViewModel);
        }
        public IActionResult AddDepartment(int? InsId,int? DepId) {
            if(InsId==null || DepId == null)
            {
                return BadRequest();
            }
            _deptInstructorRepo.Add(DepId.Value, InsId.Value);
            var instructorViewModel = PrepareInstructor(InsId.Value);
            return View("Edit", instructorViewModel);
        }
        public IActionResult DeleteDepartment(int? InsId, int? DepId)
        {
            if(InsId == null || DepId == null)
            {
                return BadRequest();
            }
            _deptInstructorRepo.Delete(DepId.Value, InsId.Value);
            var instructorViewModel = PrepareInstructor(InsId.Value);
            return View("Edit", instructorViewModel);
        }
        [HttpGet]
        public IActionResult ManageCourses(int? InsId, int? DepId)
        {
            if (InsId == null || DepId == null)
            {
                return BadRequest();
            }
            var departmentCourses = _departmentRepo.GetCourses(DepId.Value);
            var instructorCourses = _instructorRepo.GetCourses(InsId.Value);
            ViewBag.otherCourses = departmentCourses.Except(instructorCourses);
            return View(instructorCourses);
        }
        [HttpPost]
        public IActionResult ManageCourses(List<int> toRemove,List<int> toAdd,int InsId)
        {
            foreach(var item in toRemove)
            {
                var course = _courseRepo.GetById(item);
                _instructorRepo.RemoveCourse(InsId, course);
            }
            foreach (var item in toAdd)
            {
                var course = _courseRepo.GetById(item);
                _instructorRepo.AddCourse(InsId, course);
            }
            var instructorViewModel= PrepareInstructor(InsId);
            if(!(instructorViewModel.Instructor_Id > 0))
            {
                return NotFound();
            }
            return View("Edit", instructorViewModel);
        }

        //Add instructor
        [HttpGet]
        public IActionResult Add()
        {
            var departments = _departmentRepo.GetAll();
            ViewBag.Users = _userRepo.GetNonAssignedUsers();
            return View(departments);
        }
       
        
        public IActionResult AddInstructor(int? id)
        {
            if(id == null)
            {
                return BadRequest();
            }
            var instructor = new Instructor {Ins_User_Id=id.Value };
            _instructorRepo.Add(instructor);
            int d = instructor.Instructor_Id;
            _instructorRepo.AddRole(d);
            return RedirectToAction("Edit", new {id=d});
        }



        //my methods
        public InstructorViewModel PrepareInstructor(int id)
        {
            var instructor = _instructorRepo.GetById(id);
            InstructorViewModel instructorViewModel = new InstructorViewModel();

            instructorViewModel.Instructor_Id = instructor.Instructor_Id;
            instructorViewModel.Instructor_Image = instructor.Navigation_User.User_Image;
            instructorViewModel.Instructor_Email = instructor.Navigation_User.User_Email;
            instructorViewModel.Instructor_Name = instructor.Navigation_User.User_Name;
            instructorViewModel.Instructor_User_Id = instructor.Navigation_User.User_Id;

            //courses
            instructorViewModel.Courses = instructor.Navigation_Courses.ToList();
            

            //department
            var allDepartments = _departmentRepo.GetAll();
            instructorViewModel.Departments = instructor.Navigation_Department_Instructor.Select(a => a.Navigation_Department).ToList();
            instructorViewModel.OtherDepartments = allDepartments.Except(instructorViewModel.Departments).ToList();
            instructorViewModel.Managed_Departments=instructor.Navigation_Departments.ToList();
            return instructorViewModel;
        }
    }
}
