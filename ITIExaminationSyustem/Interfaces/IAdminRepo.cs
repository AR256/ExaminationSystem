using ITIExaminationSyustem.Models;

namespace ITIExaminationSyustem.Interfaces
{
    public interface IAdminRepo
    {
        List<Admin> GetAll();
        List<Admin> GetAllAdminsbyUsersEmailBranches();
        Admin GetById(int id);
        Admin GetByIdfordetails(int id);
        void Add(Admin admin);
        void Update(Admin admin);
        void Delete(int id);
    }
}
