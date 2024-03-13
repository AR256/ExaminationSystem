using ITIExaminationSyustem.Interfaces;
using ITIExaminationSyustem.Models;
using ITIExaminationSyustem.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITIExaminationSyustem.Controllers
{
    [Authorize(Roles=("Admin"))]
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
            var emailList = users.Select(u => new { Admin_User_Id = u.User_Id, User_Email = u.User_Email }).ToList();
            ViewBag.Emaillist = emailList;
            var branches = _branchRepo.GetAll();
            var branchList = branches.Select(u => new { Admin_Branch_Id = u.Branch_Id, Branch_Name = u.Branch_Name}).ToList();
            ViewBag.Branchlist = branchList;
            return View();
        }

        [HttpPost]
        public IActionResult Save(Admin admin)
        {
            _adminRepo.Add(admin);
            _adminRepo.AddRole(admin.Admin_Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var users = _userRepo.GetAll().Where(a => a.Navigation_Admin == null && a.Navigation_Instructor == null && a.Navigation_Student == null);
            var emailList = users.Select(u => new { Admin_User_Id = u.User_Id, User_Email = u.User_Email }).ToList();
            ViewBag.Emaillist = emailList;
            var branches = _branchRepo.GetAll();
            var branchList = branches.Select(u => new { Admin_Branch_Id = u.Branch_Id, Branch_Name = u.Branch_Name }).ToList();
            ViewBag.Branchlist = branchList;
            var adminedited = _adminRepo.GetById(id);
            return View(adminedited);
        }
        [HttpPost]
        public IActionResult Update(Admin admin)
        {
            _adminRepo.Update(admin);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var targetAdmin = _adminRepo.GetByIdfordetails(id);
            return View(targetAdmin);
        }
    }
}
