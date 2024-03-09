using ITIExaminationSyustem.Models;

namespace ITIExaminationSyustem.Interfaces
{
    public interface IQuestionTypeRepo
    {
        List<QuestionType> GetAll();
        QuestionType GetById(int id);
        void Add(QuestionType questionType);
        void Update(QuestionType questionType);
        void Delete(int id);
    }
}
