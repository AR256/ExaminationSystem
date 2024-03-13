using ITIExaminationSyustem.Models;

namespace ITIExaminationSyustem.Interfaces
{
    public interface IUserRepo
    {
        List<User> GetAll();
        public User GetById(int id);
        void Add(User user);
        void Update(User user);
        void Delete(int id);
        Task AddImage(User user, IFormFile image);
        List<User> GetNonAssignedUsers();
    }
}
