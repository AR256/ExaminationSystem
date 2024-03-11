using ITIExaminationSyustem.Interfaces;
using ITIExaminationSyustem.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITIExaminationSyustem.Controllers
{
    public class UserController : Controller
    {
        IUserRepo _userRepo;

        public UserController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public IActionResult Index()
        {
            List<User> users = _userRepo.GetAll();
            return View(users);
        }

        public IActionResult Details(int id)
        {
            User fetchedUser = _userRepo.GetById(id);
            return View(fetchedUser);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            if(ModelState.IsValid)
            {
                _userRepo.Add(user);
                return RedirectToAction("Index");
            }
            else
            {
                return View(user);
            }
        }

        public IActionResult Edit(int id)
        {
            User userToEdit = _userRepo.GetById(id);
            return View(userToEdit);
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                _userRepo.Update(user);
                return RedirectToAction("Index");
            }
            else
            {
                return View(user);
            }
        }

        public IActionResult Delete(int id)
        {
            _userRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
