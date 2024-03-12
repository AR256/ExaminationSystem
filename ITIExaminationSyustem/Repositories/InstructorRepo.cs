using ITIExaminationSyustem.Interfaces;
using ITIExaminationSyustem.Models;
using Microsoft.EntityFrameworkCore;

namespace ITIExaminationSyustem.Repositories
{
    public class InstructorRepo : IInstructorRepo
    {
        Exam_Context _context;

        public InstructorRepo(Exam_Context examContext)
        {
            _context = examContext;
        }
        public List<Instructor> GetAll()
        {
            return _context.Instructors.Include(a=>a.Navigation_User).ToList();
        }
        public Instructor GetById(int id)
        {
            return _context.Instructors.Include(a=>a.Navigation_User)
                                       .Include(a=>a.Courses)
                                       .Include(a=>a.Navigation_Department_Instructor)
                                       .ThenInclude(a=>a.Navigation_Department)
                                       .ThenInclude(a=>a.Navigation_MainDepartment)
                                       .SingleOrDefault(ins => ins.Instructor_Id == id);
        }
        public void Add(Instructor instructor)
        {
            _context.Instructors.Add(instructor);
            _context.SaveChanges();
        }
        public void Update(Instructor instructor)
        {
            _context.Instructors.Update(instructor);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var instructorToDelete = GetById(id);
            _context.Instructors.Remove(instructorToDelete);
            _context.SaveChanges();
        }
    }
}
