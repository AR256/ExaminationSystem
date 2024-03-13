using ITIExaminationSyustem.Interfaces;
using ITIExaminationSyustem.Models;

namespace ITIExaminationSyustem.Repositories
{
    public class QuestionTypeRepo : IQuestionTypeRepo
    {
        private Exam_Context _context;

        public QuestionTypeRepo(Exam_Context examContext)
        {
            _context = examContext;
        }
        public List<QuestionType> GetAll()
        {
            return _context.QuestionTypes.ToList();
        }
        public QuestionType GetById(int id)
        {
            return _context.QuestionTypes.SingleOrDefault(qType => qType.QuestionType_Id == id);
        }
        public void Add(QuestionType questionType)
        {
            _context.QuestionTypes.Add(questionType);
            _context.SaveChanges();
        }
        public void Update(QuestionType questionType)
        {
            _context.QuestionTypes.Update(questionType);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var qTypeToDelete = GetById(id);
            _context.QuestionTypes.Remove(qTypeToDelete);
            _context.SaveChanges();
        }        
    }
}
