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

            return _context.Instructors.Include(a=>a.Navigation_Departments)
                .Include(a=>a.Navigation_User)
                .ThenInclude(a=>a.Navigation_Roles)
                .Include(a=>a.Navigation_Courses)
                .Include(a=>a.Navigation_Department_Instructor)
                .ThenInclude(a=>a.Navigation_Department)
                .ThenInclude(a => a.Navigation_Branch)
                .Include(a => a.Navigation_Department_Instructor)
                .ThenInclude(a => a.Navigation_Department)
                .ThenInclude(a => a.Navigation_MainDepartment)
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

        public List<Course> GetCourses(int id)
        {
            return _context.Instructors.Include(a=>a.Navigation_Courses).SingleOrDefault(a=>a.Instructor_Id==id).Navigation_Courses.ToList();
        }

        public void AddCourse(int insId, Course course)
        {
            var instructor = GetById(insId);
            instructor.Navigation_Courses.Add(course);
            _context.SaveChanges();
        }
        public void RemoveCourse(int insId, Course course)
        {
            var instructor = GetById(insId);
            instructor.Navigation_Courses.Remove(course);
            _context.SaveChanges();
        }

        //public void RemoveDepartment(int insId, Department department)
        //{
        //    var instructor = GetById(insId);
        //    instructor.Navigation_Departments.Remove(department);
        //    _context.SaveChanges();
        //}
        //public void AddDepartment(int insId, Department department)
        //{
        //    var instructor = GetById(insId);
        //    instructor.Navigation_Departments.Add(department);
        //    _context.SaveChanges();

        //}

        public void AddRole(int id)
        {
            var instructor = GetById(id);
            var role = _context.Roles
                .SingleOrDefault(a => a.Role_Type == "Instructor");
            instructor?.Navigation_User?.Navigation_Roles?.Add(role);
            _context.SaveChanges();
        }
    }
}
