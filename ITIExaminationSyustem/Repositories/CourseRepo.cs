using ITIExaminationSyustem.Interfaces;
using ITIExaminationSyustem.Models;
using Microsoft.EntityFrameworkCore;

namespace ITIExaminationSyustem.Repositories
{
    public class CourseRepo : ICourseRepo
    {
        Exam_Context _context;
        public CourseRepo(Exam_Context examContext)
        {
            _context = examContext;
        }
        public void Add(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Courses.Remove(GetById(id));
            _context.SaveChanges();
        }

        public List<Course> GetAll()
        {
            return _context.Courses.ToList();
        }

        public Course GetById(int id)
        {
            return _context.Courses.Include(crs => crs.Navigation_StudentCourses)
                                   .ThenInclude(stdCrs => stdCrs.Navigation_Student)
                                   .FirstOrDefault(s => s.Course_Id == id);
        }

        public void Update(Course course)
        {
            _context.Courses.Update(course);
            _context.SaveChanges();
        }
    }
}
