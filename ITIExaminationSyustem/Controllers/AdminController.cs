using ITIExaminationSyustem.Interfaces;
using ITIExaminationSyustem.Models;
using ITIExaminationSyustem.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITIExaminationSyustem.Controllers
{
    [Authorize(Roles=("Super Admin"))]
    public class AdminController : Controller
    {
        private IAdminRepo _adminRepo;
        private IUserRepo _userRepo;
        private IBranchRepo _branchRepo;

        public AdminController(IAdminRepo adminRepo,IUserRepo userRepo, IBranchRepo branchRepo)
        {
            _adminRepo = adminRepo;
            _userRepo = userRepo;
            _branchRepo = branchRepo;
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
        [HttpGet]
        public IActionResult Add() 
        {
            var users = _userRepo.GetAll().Where(a => a.Navigation_Admin == null && a.Navigation_Instructor == null && a.Navigation_Student == null);
            var branches = _branchRepo.GetAll();
            if(users != null && branches != null)
            {
                var emailList = users.Select(u => new { Admin_User_Id = u.User_Id, User_Email = u.User_Email }).ToList();
                var branchList = branches.Select(u => new { Admin_Branch_Id = u.Branch_Id, Branch_Name = u.Branch_Name }).ToList();
                ViewBag.Emaillist = emailList;
                ViewBag.Branchlist = branchList;
                return View();
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Save(Admin admin)
        {

            if(admin != null)
            {
                if (ModelState.IsValid)
                {
                    _adminRepo.Add(admin);
                    _adminRepo.AddRole(admin.Admin_Id);
                    return RedirectToAction("Index");
                }
                return View(admin);
            }
            return BadRequest();
            

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Admin admin = _adminRepo.GetById(id);
            var email = _userRepo.GetAll().Select(u => new { Admin_User_Id = u.User_Id, User_Email = u.User_Email }).ToList();
            var branches = _branchRepo.GetAll().Where(b => b.Navigation_Admin == null);
            if(email != null && branches != null)
            {
                ViewBag.Email = email;
                var branchList = branches.Select(u => new { Admin_Branch_Id = u.Branch_Id, Branch_Name = u.Branch_Name }).ToList();
                ViewBag.Branchlist = branchList;
                var adminedited = _adminRepo.GetById(id);
                return View(adminedited);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Edit(Admin admin, int id)
        {
            if(id != null && admin != null)
            {
                Admin ad = _adminRepo.GetById(id);
                ad.Admin_Branch_Id = admin.Admin_Branch_Id;
                if (ModelState.IsValid)
                {
                    _adminRepo.Update(ad);
                    return RedirectToAction("Index");
                }
                return View(admin);
            }
            return NotFound();
            
        }

        public IActionResult Details(int id)
        {
            if(id != null)
            {
                var targetAdmin = _adminRepo.GetByIdfordetails(id);
                return View(targetAdmin);
            }
            return NotFound();
        }
    }
}
