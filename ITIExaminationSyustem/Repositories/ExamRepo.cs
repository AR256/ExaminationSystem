using ITIExaminationSyustem.Interfaces;
using ITIExaminationSyustem.Models;

namespace ITIExaminationSyustem.Repositories
{
    public class ExamRepo: IExamRepo
    {
        private Exam_Context _context;
        public ExamRepo(Exam_Context examContext)
        {
            _context = examContext;
        }
        public List<Exam> GetAll()
        {
            return _context.Exams.ToList();
             
        }

        public Exam GetById(int id)
        {
            return _context.Exams.SingleOrDefault(a=>a.Exam_Id == id);
        }

        public List<Exam> GetAllByCrsId(int id) //--> for instructor
        {
            return _context.Exams.Where(a=>a.Crs_Id==id).ToList();
        }

        public List<Exam> GetAllByStdId(int id) //--> for student
        {
            return _context.Exams.Where(a=>a.StudId==id).ToList();
        }

        public void Add(Exam exam)
        {
           
                _context.Exams.Add(exam);
            _context.SaveChanges();
        }
        public void Update(Exam exam)
        {
            _context.Exams.Update(exam);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            _context.Exams.Remove(GetById(id));
            _context.SaveChanges();
        }
    }
}
