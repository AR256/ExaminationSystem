using ITIExaminationSyustem.Interfaces;
using ITIExaminationSyustem.Models;
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
        [HttpGet]
        public IActionResult AddBranch()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Save(Branch branch)
        {
            if(branch != null)
            {
                branchRepo.Add(branch);
                return RedirectToAction("Index");
            }
            return NotFound();
        }
        public IActionResult Delete(int? id)
        {
            if(id != null)
            {
                branchRepo.Delete(id.Value);
                return RedirectToAction("Index");
            }
            return BadRequest();
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id != null)
            {
                var branchtoedited = branchRepo.GetById(id.Value);
                return View(branchtoedited);
            }
            return NotFound();
            
        }
        [HttpPost]
        public IActionResult Update(Branch branch)
        {
            if(branch != null)
            {
                branchRepo.Update(branch);
                return RedirectToAction("Index");
            }
            return BadRequest();
            
        }
        public IActionResult Details(int? id)
        {
            if(id != null)
            {
                var targetBranch = branchRepo.GetById(id.Value);
                return View(targetBranch);
            }
            return NotFound();
        }
    }
}
