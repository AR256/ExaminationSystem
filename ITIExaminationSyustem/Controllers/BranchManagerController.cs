using ITIExaminationSyustem.Interfaces;
using ITIExaminationSyustem.Models;
using ITIExaminationSyustem.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ITIExaminationSyustem.Controllers
{
    public class BranchManagerController : Controller
    {
        private IBranchManagerRepo branchManagerRepo;
        public BranchManagerController(IBranchManagerRepo branchManagerRepo)
        {
            this.branchManagerRepo = branchManagerRepo;
        }
        public IActionResult Index()
        {
            var ManagerList = branchManagerRepo.GetAll();
            return View(ManagerList);
        }
        public IActionResult AddBranchManager()
        {
            return View();
        }
        public IActionResult Save(BranchManager branchmgr)
        {
            branchManagerRepo.Add(branchmgr);
            return RedirectToAction("Index");
        }
    }
}
