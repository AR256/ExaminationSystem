using ITIExaminationSyustem.Interfaces;
using ITIExaminationSyustem.Models;
using Microsoft.EntityFrameworkCore;

namespace ITIExaminationSyustem.Repositories
{
    public class DepartmentRepo : IDepartmentRepo
    {
        Exam_Context _context;

        public DepartmentRepo(Exam_Context examContext)
        {
            _context = examContext;
        }
        public List<Department> GetAll()
        {
            return _context.Departments.Include(a=>a.Navigation_MainDepartment).ToList();
        }
        public List<Department> GetDepartmentsByBranchId(int id)
        {
            return _context.Departments.Include(a=>a.Navigation_MainDepartment).Where(a=>a.Brch_Id==id).ToList();
        }
        public Department GetById(int id)
        {
            return _context.Departments.SingleOrDefault(dept => dept.Department_Id == id);
        }
        public void Add(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
        }
        public void Update(Department department)
        {
            _context.Departments.Update(department);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var deptToDelete = GetById(id);
            _context.Departments.Remove(deptToDelete);
            _context.SaveChanges();
        }
    }
}
