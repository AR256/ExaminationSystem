using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITIExaminationSyustem.Models
{
    public class Question
    {
        [Key]
        public int Question_Id { get; set; }
        public string Question_Text { get; set; }
        public string Question_Answer { get; set; }

        [ForeignKey("Navigation_QuestionType")]
        public int? Question_Type { get; set; }

        [ForeignKey("Navigation_Course")]
        public int? Crs_Id { get; set; }


        #region Navigation property
        public ICollection<ExamQs> Navigation_ExamQs { get; set; } = new HashSet<ExamQs>();
        public QuestionType Navigation_QuestionType { get; set; }
        //----------------------------------------------------------
        public Course Navigation_Course { get; set; }

        //----------------------------------------------------------
        public ICollection<Choice> Navigation_Choices { get; set; } = new HashSet<Choice>();

        #endregion
    }
}
