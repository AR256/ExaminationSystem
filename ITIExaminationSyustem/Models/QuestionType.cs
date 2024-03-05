using System.ComponentModel.DataAnnotations;

namespace ITIExaminationSyustem.Models
{
    public class QuestionType
    {
        [Key]
        public int QuestionType_Id { get; set; }
        public int Degree { get; set; }

        #region Navigation property
        public ICollection<Question> Navigation_Question { get; set; } = new HashSet<Question>();
        #endregion
    }
}
