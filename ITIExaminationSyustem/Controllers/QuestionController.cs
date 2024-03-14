using ITIExaminationSyustem.Interfaces;
using ITIExaminationSyustem.Models;
using ITIExaminationSyustem.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITIExaminationSyustem.Controllers
{

    [Authorize]
    public class QuestionController : Controller
    {
        IQuestionRepo _questionRepo;
        ICourseRepo _courseRepo;
        IChoiceRepo _choiceRepo;
        IQuestionTypeRepo _questionTypeRepo;
        public QuestionController(IQuestionRepo questionRepo, ICourseRepo courseRepo, IChoiceRepo choiceRepo, IQuestionTypeRepo questionTypeRepo)
        {
            _questionRepo = questionRepo;
            _courseRepo = courseRepo;
            _choiceRepo = choiceRepo;
            _questionTypeRepo = questionTypeRepo;

        }
        public IActionResult Index()
        {
            var model = _questionRepo.GetAll();
            return View(model);
        }

        public IActionResult Create()
        {
            ViewBag.CrsList = _courseRepo.GetAll();
            ViewBag.TypeList = _questionTypeRepo.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Question q, Dictionary<string, string> choices) 
        {
            var m = _questionRepo.GetById(q.Question_Id);
            if (ModelState.IsValid && m == null)
            {
                if (choices.Values.ToList()[0] == null)
                {
                    q.Navigation_Choices.Add(_choiceRepo.GetById(1));
                    q.Navigation_Choices.Add(_choiceRepo.GetById(2));
                }
                else
                {
                    foreach (var i in choices)
                    {
                        var c = new Choice { Choice_Text = i.Value };

                        _choiceRepo.Add(c);
                        q.Navigation_Choices.Add(c);
                    }
                } 
                _questionRepo.Add(q);
                return RedirectToAction("Index");
            }
            else
            {
                return View(q);
            }
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return BadRequest();
            var model = _questionRepo.GetById(id.Value);
            if (model == null)
                return NotFound();
            return View(model);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return BadRequest();
            var model = _questionRepo.GetById(id.Value);
            if (model == null)
                return NotFound();
            ViewBag.CrsList = _courseRepo.GetAll();
            ViewBag.TypeList = _questionTypeRepo.GetAll();
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(Question question, int id, Dictionary<int, string> choice)
        {
            if (ModelState.IsValid)
            {
                
                question.Question_Id = id;

                foreach (var item in choice)
                {
                    var ch = _choiceRepo.GetById(item.Key);
                        ch.Choice_Text = item.Value;
                    _choiceRepo.Update(ch);
                    
                }
                _questionRepo.Update(question);
                return RedirectToAction("Index");
            }
            return View(question);

        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return BadRequest();
            var q = _questionRepo.GetById(id.Value);
            if (q.Question_Type != 1)
            {
                foreach(var i in q.Navigation_Choices)
                {
                    _choiceRepo.Delete(i.Choice_Id);
                    q.Navigation_Choices.Remove(i);
                }
            }
            _questionRepo.Delete(id.Value);
            
            return RedirectToAction("Index");
        }
    }
}
