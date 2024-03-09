using ITIExaminationSyustem.Models;

namespace ITIExaminationSyustem.Interfaces
{
    public interface IDeptInstructorRepo 
    {
        List<Department> GetDepartmentsByInsId(int id);
        List<Instructor> GetInstructorsByDeptId(int id);
    }
}
