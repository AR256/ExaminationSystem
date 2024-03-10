using Microsoft.AspNetCore.Mvc;

namespace ITIExaminationSyustem.Controllers
{
    public class BranchManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
