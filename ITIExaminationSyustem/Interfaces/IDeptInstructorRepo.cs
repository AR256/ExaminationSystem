using ITIExaminationSyustem.Models;

namespace ITIExaminationSyustem.Interfaces
{
    public interface IDeptInstructorRepo 
    {
        List<Department> GetDepartmentsByInsId(int id);
        List<Instructor> GetInstructorsByDeptId(int id);

        void Add(int depId,int InsId);
        void Delete(int depId,int InsId);
    }
}
