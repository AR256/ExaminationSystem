using ITIExaminationSyustem.Interfaces;
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
            return View();
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


              ClaimsIdentity claimIdentity = new ClaimsIdentity("Cookies");
              claimIdentity.AddClaim(nameClaim);
              claimIdentity.AddClaim(emailClaim);
              claimIdentity.AddClaim(idClaim);
              //adding each role of the user
              foreach (var item in user.Navigation_Roles)
              {
                  var roleClaim = new Claim(ClaimTypes.Role, item.Role_Type);
                  claimIdentity.AddClaim(roleClaim);

              }

              ClaimsPrincipal claimPrincipal = new ClaimsPrincipal();
              claimPrincipal.AddIdentity(claimIdentity);

              await HttpContext.SignInAsync(claimPrincipal);

              return RedirectToAction("Index","Home");
          }

        async public Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");

        }

        public IActionResult MyDetails()
        {
            ClaimsPrincipal currentUser = HttpContext.User;
            Claim idClaim = currentUser.FindFirst("id");
            var rolesClaims = currentUser.FindAll(ClaimTypes.Role);
            var Roles = rolesClaims.Select(c=>c.Value).ToList();

            int id =int.Parse(idClaim.Value);
            var studentClaim = new Claim(ClaimTypes.Role, "Student");
            var instructorClaim = new Claim(ClaimTypes.Role, "Instructor");
            if (id != null)
            {
               var user = _userRepo.GetById(id);
                if (Roles.Contains("Student"))
                {
                    var studentId = user?.Navigation_Student?.Student_Id;
                    return RedirectToAction("Details", "Student", new { id = studentId });
                }else if (Roles.Contains("Instructor"))
                {
                    var instrucotrId = user?.Navigation_Instructor?.Instructor_Id;
                    return RedirectToAction("Details", "Instructor", new { id = instrucotrId });

                }
            }
            return NotFound();
        }

    }
}
