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
        private IInstructorRepo instructorRepo;

        public BranchController(IBranchRepo branchRepo, IInstructorRepo instructorRepo)
        {
            this.branchRepo = branchRepo;
            this.instructorRepo = instructorRepo;
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
            if (id == null)
                return BadRequest();
            else
            {
                var branchToEdit = branchRepo.GetById(id.Value);
                if (branchToEdit == null)
                    return NotFound();
                else
                {
                    return View(branchToEdit);
                }
            }
            
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
