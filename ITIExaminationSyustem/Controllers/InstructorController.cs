using ITIExaminationSyustem.Interfaces;
using ITIExaminationSyustem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ITIExaminationSyustem.Controllers
{
    public class InstructorController : Controller
    {
        private IInstructorRepo _instructorRepo;
        private IBranchRepo _branchRepo { get; set; }
        public InstructorController(IInstructorRepo instructorRepo, IBranchRepo branchRepo )
        {
            _instructorRepo = instructorRepo;
            _branchRepo = branchRepo;
        }
        public IActionResult Index()
        {
            List<InstructorViewModel> instructorViewModelList = new List<InstructorViewModel>();
            
            var instructors = _instructorRepo.GetAll();
            foreach (var instructor in instructors)
            {
                InstructorViewModel instructorViewModel = new InstructorViewModel();
                instructorViewModel.Instructor_Id = instructor.Instructor_Id;
                instructorViewModel.Instructor_Image=instructor.Navigation_User.User_Image;
                instructorViewModel.Instructor_Email=instructor.Navigation_User.User_Email;
                instructorViewModel.Instructor_Name=instructor.Navigation_User.User_Name;
                instructorViewModelList.Add(instructorViewModel);
            }
            
            return View(instructorViewModelList);
        }

        public IActionResult Details(int id)
        {                                                                                                           
            return View(PrepareInstructor(id));
        }

        public IActionResult Edit(int id)
        {
            var instructor = PrepareInstructor(id);
            ViewBag.Branches = _branchRepo.GetAll();
            return View();
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
            //instructorViewModel.Instructor_BranchName = instructor.Navigation_Branch.Branch_Name;
            instructorViewModel.Departments = instructor.Navigation_Department_Instructor.Select(a => a.Navigation_Department).ToList();
            //instructorViewModel.Branch_Id = instructor.Navigation_Branch.Branch_Id;
            instructorViewModel.Courses = instructor.Courses.ToList();
            return instructorViewModel;
        }
    }
}
