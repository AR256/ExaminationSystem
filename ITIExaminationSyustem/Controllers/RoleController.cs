using ITIExaminationSyustem.Interfaces;
using ITIExaminationSyustem.Models;
using ITIExaminationSyustem.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITIExaminationSyustem.Controllers
{
    [Authorize]
    public class RoleController : Controller
    {
        IRoleRepo _roleRepo;
        public RoleController(IRoleRepo roleRepo)
        {
            _roleRepo = roleRepo;
        }
        public IActionResult Index()
        {
            var model = _roleRepo.GetAll();
            return View(model);
        }

        public IActionResult Details(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            var model = _roleRepo.GetById(id.Value);
            if (model == null)
                return NotFound();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Role role)
        {
            var m = _roleRepo.GetById(role.Role_Id);
            if (ModelState.IsValid && m == null)
            {
                _roleRepo.Add(role);
                return RedirectToAction("Index");
            }
            return View(role);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
                return BadRequest();
            var m = _roleRepo.GetById(id.Value);
            if (m == null)
                return NotFound();
            return View(m);
        }
        [HttpPost]
        public IActionResult Edit(Role role, int id)
        {
            if (ModelState.IsValid)
            {
                role.Role_Id = id;
                _roleRepo.Update(role);
                return RedirectToAction("Index");
            }
            return View(role);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
                return BadRequest();
            _roleRepo.Delete(id.Value);
            return RedirectToAction("Index");
        }
    }
}
