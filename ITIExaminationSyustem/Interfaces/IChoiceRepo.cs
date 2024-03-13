using ITIExaminationSyustem.Models;

namespace ITIExaminationSyustem.Interfaces
{
    public interface IChoiceRepo
    {
        List<Choice> GetAll();
        Choice GetById(int id);
        void Add(Choice choice);
        void Update(Choice choice);
        void Delete(int id);
    }
}
