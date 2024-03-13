using ITIExaminationSyustem.Models;

namespace ITIExaminationSyustem.Interfaces
{
    public interface IRoleRepo
    {
        List<Role> GetAll();
        void Add(Role role);
        void Update(Role role);
        void Delete(int id);
        Role GetById(int id);
        List<User> GetUsers(int id);
    }
}
