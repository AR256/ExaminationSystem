using ITIExaminationSyustem.Models;

namespace ITIExaminationSyustem.Interfaces
{
    public interface IExamQuestionRepo
    {
        List<ExamQs> GetExamQuestions(int id);
        List<ExamQs> GenerateExam(int crsId, int stdId);
        ExamQs GetByIds(int examId, int questionId);
        void CheckAnswer(ExamQs examQs);
    }
}
