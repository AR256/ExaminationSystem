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
            return _context.Departments.Include(dept=>dept.Navigation_MainDepartment)
                                       .Include(dept => dept.Navigation_Branch)
                                       .Include(dept => dept.Navigation_Students)
                                       .Include(dept => dept.Navigation_Courses)
                                       .Include(dept => dept.Navigation_Department_Instructor)
                                       .ThenInclude(deptIns => deptIns.Navigation_Instructor)
                                       .ThenInclude(mgr => mgr.Navigation_User)
                                       .ToList();
        }
        public List<Department> GetDepartmentsByBranchId(int id)
        {
            return _context.Departments.Include(a=>a.Navigation_MainDepartment)
                                       .Where(a=>a.Brch_Id==id)
                                       .ToList();
        }
        public Department GetById(int id)
        {
            return _context.Departments.Include(dept => dept.Navigation_MainDepartment)
                                       .Include(dept => dept.Navigation_Branch)
                                       .Include(dept => dept.Navigation_Students)
                                       .Include(dept => dept.Navigation_Courses)
                                       .Include(dept => dept.Navigation_Department_Instructor)
                                       .ThenInclude(deptIns => deptIns.Navigation_Instructor)
                                       .ThenInclude(mgr => mgr.Navigation_User)
                                       .Include(dept => dept.Navigation_Department_Manager_Instructor)
                                       .ThenInclude(mgr => mgr.Navigation_User)
                                       .SingleOrDefault(dept => dept.Department_Id == id);
        }
        public void Add(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
            Department fetchedDepartment = GetById(department.Department_Id);
            fetchedDepartment.Department_Name = $"{fetchedDepartment.Navigation_MainDepartment.MainDepartment_Name}-{fetchedDepartment.Navigation_Branch.Branch_Name}";
            _context.Departments.Update(fetchedDepartment);
            _context.SaveChanges();
        }
        public void Update(Department department)
        {
            _context.Departments.Update(department);
            _context.SaveChanges();
        }
        public bool Delete(int id)
        {
            var deptToDelete = GetById(id);

            if (deptToDelete.Navigation_Students.Count == 0 
             && deptToDelete.Navigation_Department_Instructor.Count == 0
             && deptToDelete.Navigation_Courses.Count == 0)
            {
                _context.Departments.Remove(deptToDelete);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public Department GetByBranchAndMainDepartment(int branchId, int mainDepId)
        {
            return _context.Departments.Include(a => a.Navigation_Courses).FirstOrDefault(a => a.Brch_Id == branchId && a.MainDept_Id == mainDepId);
        }

        public List<Course> GetCourses(int id)
        {
            var department = GetById(id);
            return department.Navigation_Courses.ToList();
        }
    }
}
