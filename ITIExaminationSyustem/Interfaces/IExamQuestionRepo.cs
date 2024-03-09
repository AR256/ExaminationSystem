using ITIExaminationSyustem.Models;

namespace ITIExaminationSyustem.Interfaces
{
    public interface IExamQuestionRepo
    {
        List<ExamQs> GetAnsweredQuestions(int id);
        List<ExamQs> GenerateExam(int crsId, int stdId);
        void SubmitAnswers(string ans,int examId,int qsId);
    }
}
