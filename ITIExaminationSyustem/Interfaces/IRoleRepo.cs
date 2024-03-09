using ITIExaminationSyustem.Models;

namespace ITIExaminationSyustem.Interfaces
{
    public interface IRoleRepo
    {
        void Add(Role role);
        void Update(Role role);
        void Delete(int id);
        List<User> GetUsers(int id);
    }
}
