using ITIExaminationSyustem.Models;

namespace ITIExaminationSyustem.Interfaces
{
    public interface IBranchManagerRepo
    {
        List<BranchManager> GetAll();
        BranchManager GetById(int id);
        void Add(BranchManager branchManager);
        void Update(BranchManager branchManager);
        void Delete(int id);
    }
}
