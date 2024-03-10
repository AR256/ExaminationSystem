using ITIExaminationSyustem.Interfaces;
using ITIExaminationSyustem.Models;
using Microsoft.EntityFrameworkCore;

namespace ITIExaminationSyustem.Repositories
{
    public class StudentRepo : IStudentRepo
    {
        Exam_Context _context;
        public StudentRepo(Exam_Context examContext) 
        {
            _context = examContext;
        }
        public void Add(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Students.Remove(GetById(id));
            _context.SaveChanges();
        }

        public List<Student> GetAll()
        {
            return _context.Students.Include(a=>a.Navigation_User).Include(a => a.Navigation_Department).ThenInclude(a=>a.Navigation_MainDepartment).ToList();
        }

        public Student GetById(int id)
        {
            return _context.Students.Include(a => a.Navigation_StudentCourses).ThenInclude(a=>a.Navigation_Course).Include(a => a.Navigation_StudentExam).Include(a => a.Navigation_User).Include(a => a.Navigation_Department).ThenInclude(a => a.Navigation_MainDepartment).FirstOrDefault(s => s.Student_Id == id);
        }

        public void Update(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
        }
    }
}
