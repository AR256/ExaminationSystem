using ITIExaminationSyustem.Interfaces;
using ITIExaminationSyustem.Models;
using ITIExaminationSyustem.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ITIExaminationSyustem.Controllers
{
    public class ExamController : Controller
    {
        IExamRepo _examRepo;
        IQuestionRepo _questionRepo;
        IChoiceRepo _choiceRepo;
        IExamQuestionRepo _examQuestionRepo;
        IStudentCourseRepo _studentCourseRepo;
        public ExamController(IExamRepo examRepo, IQuestionRepo questionRepo, IChoiceRepo choiceRepo, IExamQuestionRepo examQuestionRepo, IStudentCourseRepo studentCourseRepo)
        {
            _examRepo = examRepo;
            _questionRepo = questionRepo;
            _choiceRepo = choiceRepo;
            _examQuestionRepo = examQuestionRepo;
            _studentCourseRepo = studentCourseRepo;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TakeExam(int? crsId, int? stdId)
        {
            if(crsId == null || stdId == null)
            {
                return BadRequest();
            }
            else
            {
                StudentCourse studentCourse = _studentCourseRepo.GetByIds(crsId.Value, stdId.Value);
                if(studentCourse == null)
                {
                    return NotFound();
                }
                else
                {
                    List<ExamQs> examQuestions = _examQuestionRepo.GenerateExam(crsId.Value, stdId.Value);
                    return View(examQuestions);
                }
            }
        }

        [HttpPost]
        public IActionResult TakeExam(int examId, Dictionary<int,string> questions)
        {
            foreach(var question in questions)
            {
                ExamQs examQs = _examQuestionRepo.GetByIds(examId, question.Key);
                examQs.Student_Answer = question.Value;
                _examQuestionRepo.CheckAnswer(examQs);
            }
            return RedirectToAction("Home");
        }

        public IActionResult DisplayExamTemplate(int? examId, bool? isAnswered)
        {
            if (examId == null || isAnswered == null)
            {
                return BadRequest();
            }
            else
            {
                Exam exam = _examRepo.GetById(examId.Value);
                if (exam == null)
                {
                    return NotFound();
                }
                else
                {
                    ViewBag.Answered = isAnswered;
                    List<ExamQs> examQuestions = _examQuestionRepo.GetExamQuestions(examId.Value);
                    return View(examQuestions);
                }
            }
        }
    }
}
