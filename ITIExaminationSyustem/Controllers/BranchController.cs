using ITIExaminationSyustem.Interfaces;
using ITIExaminationSyustem.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ITIExaminationSyustem.Controllers
{
    public class BranchController : Controller
    {
        private IBranchRepo branchRepo;

        public BranchController(IBranchRepo branchRepo)
        {
            this.branchRepo = branchRepo;
        }
        public IActionResult Index()
        {
            var branchList = branchRepo.GetAll();
            return View(branchList);
        }
    }
}
