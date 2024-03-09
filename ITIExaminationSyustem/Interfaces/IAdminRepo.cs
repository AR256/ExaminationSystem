using ITIExaminationSyustem.Models;

namespace ITIExaminationSyustem.Interfaces
{
    public interface IAdminRepo
    {
        List<Admin> GetAll();
        Admin GetById(int id);
        void Add(Admin admin);
        void Update(Admin admin);
        void Delete(int id);
    }
}
