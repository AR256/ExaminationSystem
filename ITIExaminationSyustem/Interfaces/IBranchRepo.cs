using ITIExaminationSyustem.Models;

namespace ITIExaminationSyustem.Interfaces
{
    public interface IBranchRepo
    {
        List<Branch> GetAll();
        Branch GetById(int id);
        void Add(Branch branch);
        void Update(Branch branch);
        void Delete(int id);
    }
}
