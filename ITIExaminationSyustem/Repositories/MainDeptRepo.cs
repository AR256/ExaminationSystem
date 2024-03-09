using ITIExaminationSyustem.Interfaces;
using ITIExaminationSyustem.Models;

namespace ITIExaminationSyustem.Repositories
{
    public class MainDeptRepo : IMainDeptRepo
    {
        Exam_Context _context;

        public MainDeptRepo(Exam_Context examContext)
        {
            _context = examContext;
        }
        public List<MainDepartment> GetAll()
        {
            return _context.MainDepartments.ToList();
        }
        public MainDepartment GetById(int id)
        {
            return _context.MainDepartments.SingleOrDefault(mainDept => mainDept.MainDepartment_Id == id);
        }
        public void Add(MainDepartment mainDepartment)
        {
            _context.MainDepartments.Add(mainDepartment);
            _context.SaveChanges();
        }
        public void Update(MainDepartment mainDepartment)
        {
            _context.MainDepartments.Update(mainDepartment);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var mainDeptToDelete = GetById(id);
            _context.MainDepartments.Remove(mainDeptToDelete);
            _context.SaveChanges();
        }
    }
}