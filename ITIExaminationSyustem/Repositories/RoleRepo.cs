using ITIExaminationSyustem.Interfaces;
using ITIExaminationSyustem.Models;
using Microsoft.EntityFrameworkCore;

namespace ITIExaminationSyustem.Repositories
{
    public class RoleRepo : IRoleRepo
    {
        private Exam_Context _context;

        public RoleRepo(Exam_Context examContext)
        {
            _context = examContext;
        }

        public void Add(Role role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var roleToDelete = GetById(id);
            _context.Roles.Remove(roleToDelete);
            _context.SaveChanges();
        }

        public Role GetById(int id)
        {
            return _context.Roles.Include(Role => Role.Navigation_Users).SingleOrDefault(Role => Role.Role_Id == id);
        }

        public List<User> GetUsers(int id)
        {
            return GetById(id).Navigation_Users.ToList();
        }

        public void Update(Role role)
        {
            _context.Roles.Update(role);
            _context.SaveChanges();
        }
    }
}
