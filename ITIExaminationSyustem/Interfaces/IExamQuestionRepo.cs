using ITIExaminationSyustem.Models;

namespace ITIExaminationSyustem.Interfaces
{
    public interface IExamQuestionRepo
    {
        List<ExamQs> GetAnsweredQuestions(int id);
        List<ExamQs> GenerateExam(int crsId, int stdId);
        ExamQs GetByIds(int examId, int questionId);
        void CheckAnswer(ExamQs examQs);
    }
}
