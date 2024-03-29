﻿using ITIExaminationSyustem.Interfaces;
using ITIExaminationSyustem.Models;
using ITIExaminationSyustem.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging;
using System.Security.Claims;

namespace ITIExaminationSyustem.Controllers
{
    public class AccountController : Controller
    {
        IUserRepo _userRepo;
      
        public AccountController(IUserRepo userRepo) { 
            _userRepo = userRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login(LoginViewModel loginViewModel,int? dum)
        {
            if(User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
            
        }

        [HttpPost]
        async public Task<IActionResult> Login(LoginViewModel loginViewModel)
          {
              var user = _userRepo.Login(loginViewModel.User_Email,loginViewModel.User_Password);
              if(user == null) {
                  ModelState.AddModelError("","User name and password are invalid");
                  return View(loginViewModel);
              }
              //set the cookie
              var nameClaim = new Claim(ClaimTypes.Name , user.User_Name);
              var emailClaim = new Claim(ClaimTypes.Email , user.User_Email);
              var idClaim = new Claim("id",user.User_Id.ToString());
            var imageClaim = new Claim("image",user?.User_Image??"");


              ClaimsIdentity claimIdentity = new ClaimsIdentity("Cookies");
              claimIdentity.AddClaim(nameClaim);
              claimIdentity.AddClaim(emailClaim);
              claimIdentity.AddClaim(idClaim);
              claimIdentity.AddClaim(imageClaim);
              //adding each role of the user
              foreach (var item in user.Navigation_Roles)
              {
                var roleClaim = new Claim(ClaimTypes.Role, item.Role_Type);
                claimIdentity.AddClaim(roleClaim);
                switch (item.Role_Type)
                {
                    case "Admin":
                        var adminClaim = new Claim("adminBranch", user.Navigation_Admin.Admin_Branch_Id.ToString());
                        claimIdentity.AddClaim(adminClaim);
                        break;
                    case "Student":
                        var studentClaim = new Claim("studentID", user.Navigation_Student.Student_Id.ToString());
                        claimIdentity.AddClaim(studentClaim);
                        break;
                    case "Instructor":
                        var InstructorClaim = new Claim("InstructorID", user.Navigation_Instructor.Instructor_Id.ToString());
                        claimIdentity.AddClaim(InstructorClaim);
                        break;
                    case "DeptManager":
                        var DeptInstructorClaim = new Claim("DeptManagerID", user.Navigation_Instructor.Instructor_Id.ToString());
                        claimIdentity.AddClaim(DeptInstructorClaim);
                        break;
                        default:
                        break;
                }
              }

              ClaimsPrincipal claimPrincipal = new ClaimsPrincipal();
              claimPrincipal.AddIdentity(claimIdentity);

              await HttpContext.SignInAsync(claimPrincipal);

              return RedirectToAction("Index","Home");
          }

        async public Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");

        }

        public IActionResult MyDetails()
        {
            ClaimsPrincipal currentUser = HttpContext.User;
            Claim idClaim = currentUser.FindFirst("id");
            var rolesClaims = currentUser.FindAll(ClaimTypes.Role);
            var Roles = rolesClaims.Select(c=>c.Value).ToList();

            int id;
            bool validId = int.TryParse(idClaim.Value, out id);

            if (validId)
            {
               var user = _userRepo.GetById(id);
                if (Roles.Contains("Student"))
                {
                    var userId = user?.User_Id;
                    return RedirectToAction("UserDetails", "User", new { id = userId });
                    //var studentId = user?.Navigation_Student?.Student_Id;
                    //return RedirectToAction("Details", "Student", new { id = studentId });
                }
                else if (Roles.Contains("Instructor"))
                {
                    var userId = user?.User_Id;
                    return RedirectToAction("UserDetails", "User", new { id = userId });
                    //var instrucotrId = user?.Navigation_Instructor?.Instructor_Id;
                    //return RedirectToAction("Details", "Instructor", new { id = instrucotrId });
                }
                else if (Roles.Contains("Admin"))
                {
                    var userId = user?.User_Id;
                    return RedirectToAction("UserDetails", "User", new { id = userId });
                    //var adminId = user?.Navigation_Admin?.Admin_Id;
                    //return RedirectToAction("Details", "Admin", new { id = adminId });
                }
                else if (Roles.Contains("DeptManager"))
                {
                    var userId = user?.User_Id;
                    return RedirectToAction("UserDetails", "User", new { id = userId });
                    //var instrucotrId = user?.Navigation_Instructor?.Instructor_Id;
                    //return RedirectToAction("Details", "Instructor", new { id = instrucotrId });
                }
                else if (Roles.Contains("SuperAdmin"))
                {
                    var userId = user?.User_Id;
                    return RedirectToAction("UserDetails", "User", new { id = userId });
                }
            }
            return NotFound();
        }

    }
}
