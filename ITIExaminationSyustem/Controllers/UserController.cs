using ITIExaminationSyustem.Interfaces;
using ITIExaminationSyustem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ITIExaminationSyustem.Controllers
{
    public class UserController : Controller
    {
        IUserRepo _userRepo;
        IAdminRepo _adminRepo;
        IInstructorRepo _instructorRepo;
        IStudentRepo _studentRepo;

        public UserController(IUserRepo userRepo, IAdminRepo adminRepo, IInstructorRepo instructorRepo, IStudentRepo studentRepo)
        {
            _userRepo = userRepo;
            _adminRepo = adminRepo;
            _instructorRepo = instructorRepo;
            _studentRepo = studentRepo;
        }

        public IActionResult Index()
        {
            List<User> users = _userRepo.GetAll();
            _userRepo.GetNonAssignedUsers();
            return View(users);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            else
            {
                User fetchedUser = _userRepo.GetById(id.Value);
                if (fetchedUser == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(fetchedUser);
                }
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        async public Task<IActionResult> Create(User user, IFormFile image)
        {
            if(ModelState.IsValid)
            {
                _userRepo.Add(user);
                await _userRepo.AddImage(user, image);
                return RedirectToAction("Index");
            }
            else
            {
                return View(user);
            }
        }

        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return BadRequest();
            }
            else
            {
                User userToEdit = _userRepo.GetById(id.Value);
                if(userToEdit == null) 
                { 
                    return NotFound();
                }
                else
                {
                    return View(userToEdit);
                }
            }
        }

        [HttpPost]
        async public Task<IActionResult> Edit(User user, int id, IFormFile image)
        {
            user.User_Id = id;
            if (ModelState.IsValid)
            {
                _userRepo.Update(user);
                await _userRepo.AddImage(user, image);
                return RedirectToAction("Index");
            }
            else
            {
                return View(user);
            }
        }

        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return BadRequest();
            }
            else
            {
                User user = _userRepo.GetById(id.Value);
                if (user == null)
                {
                    return NotFound();
                }
                else
                {
                    if (user.Navigation_Instructor != null)
                        _instructorRepo.Delete(user.Navigation_Instructor.Instructor_Id);

                    else if (user.Navigation_Student != null)
                        _studentRepo.Delete(user.Navigation_Student.Student_Id);

                    else if (user.Navigation_Admin != null)
                        _adminRepo.Delete(user.Navigation_Admin.Admin_Id);

                    _userRepo.Delete(id.Value);
                    return RedirectToAction("Index");
                }
            }
        }
    }
}
