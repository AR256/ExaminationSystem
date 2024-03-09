using ITIExaminationSyustem.Interfaces;
using ITIExaminationSyustem.Models;

namespace ITIExaminationSyustem.Repositories
{
    public class BranchManagerRepo : IBranchManagerRepo
    {
        Exam_Context _context;
        public BranchManagerRepo(Exam_Context ExamContext)
        {
            _context = ExamContext;
        }
        public void Add(BranchManager branchManager)
        {
            _context.BranchManagers.Add(branchManager);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.BranchManagers.Remove(GetById(id));
            _context.SaveChanges();
        }

        public List<BranchManager> GetAll()
        {
            return _context.BranchManagers.ToList();
        }

        public BranchManager GetById(int id)
        {
            return _context.BranchManagers.FirstOrDefault(b=>b.Branch_Manager_Id == id);
        }

        public void Update(BranchManager branchManager)
        {
            _context.BranchManagers.Update(branchManager);
            _context.SaveChanges();
        }
    }
}
