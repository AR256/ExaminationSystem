using ITIExaminationSyustem.Interfaces;
using ITIExaminationSyustem.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

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
                                 .Include(user => user.Navigation_Roles)
                                 .ToList();
        }

        public User GetById(int id)
        {
            return _context.Users.Include(user => user.Navigation_Instructor)
                                 .Include(user => user.Navigation_Student)
                                 .Include(user => user.Navigation_Admin)
                                 .Include(user => user.Navigation_Roles)
                                 .SingleOrDefault(user => user.User_Id == id);
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
            User user = GetById(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        async public Task AddImage(User user, IFormFile image)
        {
            if (image != null)
            {
                string fileExt = image.FileName.Split('.').Last();
                string imagePath = $"wwwroot/Images/img-{user.User_Id}.{fileExt}";
                using (var fs = new FileStream(imagePath, FileMode.Create))
                {
                    await image.CopyToAsync(fs);
                }
                user.User_Image = $"/Images/img-{user.User_Id}.{fileExt}";
                _context.SaveChanges();
            }
        }

        public List<User> GetNonAssignedUsers()
        {
            List<User> allUsers = GetAll();
            List<User> requiredUsers = new();

            foreach(var user in allUsers)
            {
                if(user.Navigation_Admin == null && user.Navigation_Instructor == null && user.Navigation_Student == null)
                {
                    requiredUsers.Add(user);
                }
            }

            return requiredUsers;
        }

        public User Login(string email, string password)
        {
            return _context.Users.Include(a=>a.Navigation_Roles)
                                 .Include(a => a.Navigation_Admin)
                                 .Include(a => a.Navigation_Instructor)
                                 .Include(a => a.Navigation_Student)
                                 .SingleOrDefault(a => a.User_Email == email && a.User_Password == password);
        }
    }
}