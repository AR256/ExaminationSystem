using ITIExaminationSyustem.Models;

namespace ITIExaminationSyustem.Interfaces
{
    public interface IExamRepo
    {
        List<Exam> GetAll();
        Exam GetById(int id);
        List<Exam> GetAllByCrsId(int id); //--> for instructor
        List<Exam> GetAllByStdId(int id); //--> for student
        void Add(Exam exam);
        void Update(Exam exam);
        void Delete(int id);
    }
}
