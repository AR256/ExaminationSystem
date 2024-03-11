using ITIExaminationSyustem.Interfaces;
using ITIExaminationSyustem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ITIExaminationSyustem.Controllers
{
    public class InstructorController : Controller
    {
        private IInstructorRepo _instructorRepo;
        public InstructorController(IInstructorRepo instructorRepo) {
            _instructorRepo = instructorRepo;
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
    }
}
