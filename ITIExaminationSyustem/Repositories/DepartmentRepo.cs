using ITIExaminationSyustem.Interfaces;
using ITIExaminationSyustem.Models;

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
            return _context.Departments.ToList();
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
            var deptToDelete = _context.Departments.SingleOrDefault(dept => dept.Department_Id == id);
            _context.Departments.Remove(deptToDelete);
            _context.SaveChanges();
        }
    }
}
