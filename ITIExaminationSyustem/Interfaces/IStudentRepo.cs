using ITIExaminationSyustem.Models;

namespace ITIExaminationSyustem.Interfaces
{
    public interface IStudentRepo
    {
        List<Student> GetAll();
        Student GetById(int id);
        void Add(Student student);
        void Update(Student student);
        void Delete(int id);

         void AddRole(int id);

    }
}
