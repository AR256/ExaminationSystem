using ITIExaminationSyustem.Models;

namespace ITIExaminationSyustem.Interfaces
{
    public interface IDepartmentRepo
    {
        List<Department> GetAll();
        List<Department> GetDepartmentsByBranchId(int id);
        Department GetById(int id);
        void Add(Department department);
        void Update(Department department);
        void Delete(int id);
    }
}
