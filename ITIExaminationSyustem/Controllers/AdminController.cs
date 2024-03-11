using ITIExaminationSyustem.Interfaces;
using ITIExaminationSyustem.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ITIExaminationSyustem.Controllers
{
    public class AdminController : Controller
    {
        private IAdminRepo _adminRepo;

        public AdminController(IAdminRepo adminRepo)
        {
           _adminRepo = adminRepo;
        }

        public IActionResult AddnewBranch()
        {
            return View();
        }

        public IActionResult Index()
        {
           var adminlist = _adminRepo.GetAllAdminsbyUsersEmailBranches();
            return View(adminlist);
        }
    }
}
