using ITIExaminationSyustem.Interfaces;
using ITIExaminationSyustem.Models;

namespace ITIExaminationSyustem.Repositories
{
    public class BranchRepo : IBranchRepo
    {
        private Exam_Context _context;

        public BranchRepo(Exam_Context exam_Context)
        {
            _context = exam_Context;
        }
        public List<Branch> GetAll()
        {
            return _context.Branches.ToList();
        }

        public Branch GetById(int id)
        {
            return _context.Branches.SingleOrDefault(branch => branch.Branch_Id == id);
        }
        public void Add(Branch branch)
        {
            _context.Branches.Add(branch);
            _context.SaveChanges();
        }
        public void Update(Branch branch)
        {
            _context.Branches.Update(branch);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var branchToDelete = _context.Branches.SingleOrDefault(branch => branch.Branch_Id == id);
            _context.Branches.Remove(branchToDelete);
            _context.SaveChanges();
        }
    }
}
