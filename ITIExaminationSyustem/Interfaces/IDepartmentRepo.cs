using ITIExaminationSyustem.Models;

namespace ITIExaminationSyustem.Interfaces
{
    public interface IDepartmentRepo
    {
        List<Department> GetAll();
        List<Department> GetDepartmentsByBranchId(int id);
        Department GetById(int id);
        List<Course> GetCourses(int id);
        Department GetByBranchAndMainDepartment(int branchId,int mainDepId);
        void Add(Department department);
        void Update(Department department);
        bool Delete(int id);
    }
}
