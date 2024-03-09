using ITIExaminationSyustem.Models;

namespace ITIExaminationSyustem.Interfaces
{
    public interface IUserRepo
    {
        void Add(User user);
        void Update(User user);
        void Delete(int id);

        List<Role> GetRoles(int id);
    }
}
