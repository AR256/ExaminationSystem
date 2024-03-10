using ITIExaminationSyustem.Interfaces;
using ITIExaminationSyustem.Models;
using ITIExaminationSyustem.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ITIExaminationSyustem.Controllers
{
    public class BranchController : Controller
    {
        private IBranchRepo branchRepo;
        private IBranchManagerRepo branchManagerRepo;

        public BranchController(IBranchRepo branchRepo, IBranchManagerRepo branchManagerRepo)
        {
            this.branchRepo = branchRepo;
            this.branchManagerRepo = branchManagerRepo;
        }
        public IActionResult Index()
        {
            var branchList = branchRepo.GetAll();
            ViewBag.Branch_Manager_Name = branchManagerRepo.GetAll();
            return View(branchList);
        }
        [HttpGet]
        public IActionResult AddBranch()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Save(Branch branch)
        {
            branchRepo.Add(branch);
            return RedirectToAction("Index");
        }
    }
}
