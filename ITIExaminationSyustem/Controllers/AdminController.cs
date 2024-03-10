using ITIExaminationSyustem.Interfaces;
using ITIExaminationSyustem.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ITIExaminationSyustem.Controllers
{
    public class AdminController : Controller
    {
        private IBranchRepo branchRepo;

        public AdminController(IBranchRepo branchRepo)
        {
            this.branchRepo = branchRepo;
        }

        public IActionResult AddnewBranch()
        {
            return View();
        }

        public IActionResult Index()
        {
            var branchlist = branchRepo.GetAll();
            return View(branchlist);
        }
    }
}
