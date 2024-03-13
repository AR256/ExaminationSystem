using ITIExaminationSyustem.Interfaces;
using ITIExaminationSyustem.Models;
using ITIExaminationSyustem.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITIExaminationSyustem.Controllers
{
    [Authorize]
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
        public IActionResult Delete(int id)
        {
            branchRepo.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var branchtoedited = branchRepo.GetById(id);
            return View(branchtoedited);
        }
        [HttpPost]
        public IActionResult Update(Branch branch)
        {
            branchRepo.Update(branch);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var targetBranch = branchRepo.GetById(id);
            return View(targetBranch);
        }
    }
}
