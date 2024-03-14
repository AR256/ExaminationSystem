using ITIExaminationSyustem.Interfaces;
using ITIExaminationSyustem.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
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
            else
            {
                //set the cookie
                Claim nameClaim = new Claim(ClaimTypes.Name, user.User_Name);
                Claim emailClaim = new Claim(ClaimTypes.Email, user.User_Email);

                ClaimsIdentity claimIdentity = new ClaimsIdentity("Cookies");
                claimIdentity.AddClaim(nameClaim);
                claimIdentity.AddClaim(emailClaim);

                //adding each role of the user
                foreach (var item in user.Navigation_Roles)
                {
                    var roleClaim = new Claim(ClaimTypes.Role, item.Role_Type);
                    claimIdentity.AddClaim(roleClaim);
                }

                ClaimsPrincipal claimPrincipal = new ClaimsPrincipal();
                claimPrincipal.AddIdentity(claimIdentity);

                await HttpContext.SignInAsync(claimPrincipal);

                return RedirectToAction("Index", "Home");
            }
        }

        async public Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");

        }
    }
}
