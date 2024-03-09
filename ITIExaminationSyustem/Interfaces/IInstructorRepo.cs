using ITIExaminationSyustem.Models;

namespace ITIExaminationSyustem.Interfaces
{
    public interface IInstructorRepo
    {
        List<Instructor> GetAll();
        Instructor GetById(int id);
        void Add(Instructor instructor);
        void Update(Instructor instructor);
        void Delete(int id);
    }
}
