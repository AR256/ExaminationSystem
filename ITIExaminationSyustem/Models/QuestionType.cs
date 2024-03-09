using System.ComponentModel.DataAnnotations;

namespace ITIExaminationSyustem.Models
{
    public class QuestionType
    {
        [Key]
        public int QuestionType_Id { get; set; }
        public int Degree { get; set; }
        public string Type {  get; set; } // MCQ T&F



        #region Navigation property
        public ICollection<Question> Navigation_Question { get; set; } = new HashSet<Question>();
        #endregion
    }
}
