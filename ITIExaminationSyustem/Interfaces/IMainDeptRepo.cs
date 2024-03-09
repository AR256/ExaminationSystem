using ITIExaminationSyustem.Models;

namespace ITIExaminationSyustem.Interfaces
{
    public interface IMainDeptRepo
    {
        List<MainDepartment> GetAll();
        MainDepartment GetById(int id);
        void Add(MainDepartment mainDepartment);
        void Update(MainDepartment mainDepartment);
        void Delete(int id);
    }
}
