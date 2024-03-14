using ITIExaminationSyustem.Interfaces;
using ITIExaminationSyustem.Models;
using Microsoft.EntityFrameworkCore;

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

        public List<Admin> GetAllAdminsbyUsersEmailBranches()
        {
            return _context.Admins.Include(a=>a.Navigation_User).Include(c=>c.Navigation_Branch).ToList();
        }
        
        public Admin GetById(int id)
        {
            return _context.Admins
                .Include(a=>a.Navigation_User)
                .ThenInclude(a => a.Navigation_Roles)
                .FirstOrDefault(a=>a.Admin_Id == id);
        }
        public Admin GetByIdfordetails(int id)
        {
            return _context.Admins.Include(a => a.Navigation_User).Include(c => c.Navigation_Branch).FirstOrDefault(a => a.Admin_Id == id);
        }

       

        public void Update(Admin admin)
        {
            _context.Admins.Update(admin);
            _context.SaveChanges();
        }

        public void AddRole(int id)
        {
            var admin=GetById(id); 
            var role = _context.Roles
                .SingleOrDefault(a => a.Role_Type == "Admin");
            admin?.Navigation_User?.Navigation_Roles?.Add(role);
            _context.SaveChanges();
        }
    }
}
