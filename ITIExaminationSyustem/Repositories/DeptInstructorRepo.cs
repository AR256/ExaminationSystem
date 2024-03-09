using ITIExaminationSyustem.Interfaces;
using ITIExaminationSyustem.Models;

namespace ITIExaminationSyustem.Repositories
{
    public class DeptInstructorRepo : IDeptInstructorRepo
    {
        private Exam_Context _context;
        public DeptInstructorRepo(Exam_Context examContext)
        {
            _context = examContext; 
        }

        List<Department> IDeptInstructorRepo.GetDepartmentsByInsId(int id)
        {
            return _context.Departments.Where(dept => dept.Navigation_Department_Instructor.Any(ins => ins.Ins_Id == id)).ToList(); //.select
        }

        List<Instructor> IDeptInstructorRepo.GetInstructorsByDeptId(int id)
        {
            return _context.Instructors.Where(ins => ins.Navigation_Department_Instructor.Any(dept => dept.Dept_Id == id)).ToList();  //.select  
        }
    }
}
