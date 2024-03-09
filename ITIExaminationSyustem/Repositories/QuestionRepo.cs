using ITIExaminationSyustem.Interfaces;
using ITIExaminationSyustem.Models;

namespace ITIExaminationSyustem.Repositories
{
    public class QuestionRepo : IQuestionRepo
    {
        Exam_Context _context;

        public QuestionRepo(Exam_Context examContext)
        {
            _context = examContext;
        }
        public List<Question> GetAll()
        {
            return _context.Questions.ToList();
        }
        public Question GetById(int id)
        {
            return _context.Questions.SingleOrDefault(question => question.Question_Id == id);
        }
        public void Add(Question question)
        {
            _context.Questions.Add(question);
            _context.SaveChanges();
        }
        public void Update(Question question)
        {
            _context.Questions.Update(question);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var questionToDelete = GetById(id);
            _context.Questions.Remove(questionToDelete);
            _context.SaveChanges();
        }
    }
}
