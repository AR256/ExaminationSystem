using ITIExaminationSyustem.Interfaces;
using ITIExaminationSyustem.Models;
using Microsoft.EntityFrameworkCore;

namespace ITIExaminationSyustem.Repositories
{
    public class UserRepo : IUserRepo
    {
        Exam_Context _context;

        public UserRepo(Exam_Context examContext)
        {
            _context = examContext;
        }

        public List<User> GetAll()
        {
            return _context.Users.Include(user => user.Navigation_Instructor)
                                 .Include(user => user.Navigation_Student)
                                 .Include(user => user.Navigation_Admin)
                                 .Include(user => user.Navigation_BranchManager)
                                 .ToList();
        }

        public User GetById(int id)
        {
            return _context.Users.Include(user => user.Navigation_Roles).SingleOrDefault(user => user.User_Id == id);
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            User user = _context.Users.FirstOrDefault(s => s.User_Id == id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        //switching lists
        //public List<Role> GetRoles(int id)
        //{
        //    User user = _context.Users.Include(u=>u.Navigation_Roles).SingleOrDefault(u=>u.User_Id == id);
        //    return user.Navigation_Roles.ToList();
        //}
    }
}
