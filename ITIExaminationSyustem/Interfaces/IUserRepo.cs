using ITIExaminationSyustem.Models;

namespace ITIExaminationSyustem.Interfaces
{
    public interface IUserRepo
    {
        List<User> GetAll(); // ---> Added //
        public User GetById(int id); // ---> Added //
        void Add(User user);
        void Update(User user);
        void Delete(int id);

        /*List<Role> GetRoles(int id);*/ // ---> Deleted //
    }
}
