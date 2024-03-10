using ITIExaminationSyustem.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ITIExaminationSyustem.Controllers
{
    public class AdminController : Controller
    {
        private BranchRepo branchRepo;

        public AdminController(BranchRepo branchRepo)
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
