using ITIExaminationSyustem.Interfaces;
using ITIExaminationSyustem.Models;
using Microsoft.EntityFrameworkCore;

namespace ITIExaminationSyustem.Repositories
{
    public class StudentCourseRepo : IStudentCourseRepo
    {
        Exam_Context _context;
        public StudentCourseRepo(Exam_Context ExamContext)
        {
            _context = ExamContext;
        }

        public StudentCourse GetByIds(int crsId, int stdId)
        {
            return _context.StudentCourses.SingleOrDefault(stdCrs => stdCrs.Std_Id == stdId && stdCrs.Crs_Id == crsId);
        }

        public List<string> GetCourseFeedbacks(int courseId)
        {
            return _context.StudentCourses.Where(c => c.Crs_Id == courseId).Select(s=>s.Std_Feedback).ToList();
        }

        public List<Student> GetCourseStudents(int id)
        {
            Course crs = _context.Courses.Include(c=>c.Navigation_StudentCourses).ThenInclude(cs=>cs.Navigation_Student).SingleOrDefault(c=>c.Course_Id == id);
            var students = crs.Navigation_StudentCourses.Select(s=>s.Navigation_Student).ToList();
            return students;
        }

        public StudentCourse GetStudentCourseDetails(int studentId, int courseId)
        {
            return _context.StudentCourses.FirstOrDefault(s=>s.Std_Id == studentId && s.Crs_Id == courseId);
        }

        public List<Course> GetStudentCourses(int id)
        {
            Student std = _context.Students.Include(s => s.Navigation_StudentCourses).ThenInclude(cs => cs.Navigation_Course).SingleOrDefault(s => s.Student_Id == id);
            var courses = std.Navigation_StudentCourses.Select(s => s.Navigation_Course).ToList();
            return courses;
        }

        public List<string> GetStudentFeedbacks(int studentId)
        {
            return _context.StudentCourses.Where(s=>s.Std_Id == studentId).Select(s=>s.Std_Feedback).ToList();
        }

        public void UpdateStudentFeedback(int studentId, int courseId, string feedback)
        {
            var stdCrs = GetStudentCourseDetails(studentId, courseId);
            stdCrs.Std_Feedback = feedback;
            _context.StudentCourses.Update(stdCrs);
            _context.SaveChanges();
        }

        public void Add(int studentId, int courseId)
        {
            _context.StudentCourses.Add(new StudentCourse { Crs_Id= courseId ,Std_Id=studentId,Bouns=0} );
            _context.SaveChanges();
        }

    }
}
