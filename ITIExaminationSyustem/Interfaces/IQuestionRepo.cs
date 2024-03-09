using ITIExaminationSyustem.Models;

namespace ITIExaminationSyustem.Interfaces
{
    public interface IQuestionRepo
    {
        List<Question> GetAll();
        Question GetById(int id);
        void Add(Question question);
        void Update(Question question);
        void Delete(int id);
    }
}
