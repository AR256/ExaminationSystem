using ITIExaminationSyustem.Interfaces;
using ITIExaminationSyustem.Models;

namespace ITIExaminationSyustem.Repositories
{
    public class AdminRepo : IAdminRepo
    {
        Exam_Context _context;
        public AdminRepo(Exam_Context ExamContext)
        {
            _context = ExamContext;
        }
        public void Add(Admin admin)
        {
            _context.Admins.Add(admin);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Admins.Remove(GetById(id));
            _context.SaveChanges();
        }

        public List<Admin> GetAll()
        {
            return _context.Admins.ToList();
        }

        public Admin GetById(int id)
        {
            return _context.Admins.FirstOrDefault(a => a.Admin_Id == id);
        }

        public void Update(Admin admin)
        {
            _context.Admins.Update(admin);
            _context.SaveChanges();
        }
    }
}
