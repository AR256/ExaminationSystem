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

        public ActionResult Index()
        {
            List<User> users = _userRepo.GetAll();
            return View(users);
        }

        public ActionResult Details(int id)
        {
            User fetchedUser = _userRepo.GetById(id);
            return View(fetchedUser);
        }

    }
}
