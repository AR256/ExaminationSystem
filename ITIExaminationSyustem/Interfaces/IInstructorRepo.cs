using ITIExaminationSyustem.Models;

namespace ITIExaminationSyustem.Interfaces
{
    public interface IInstructorRepo
    {
        List<Instructor> GetAll();
        Instructor GetById(int id);
        List<Course> GetCourses(int id );
        void Add(Instructor instructor);
        void Update(Instructor instructor);
        void Delete(int id);
        void AddCourse(int insId,Course course);
        void RemoveCourse(int insId, Course course);
        //void RemoveDepartment(int insId, Department department);
        //void AddDepartment(int insId, Department department);

    }
}
