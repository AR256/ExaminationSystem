using ITIExaminationSyustem.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITIExaminationSyustem.Models
{
    public class ExamQs
    {
        [ForeignKey("Navigation_Exam")]
        public int? Exam_Id { get; set; }
        [ForeignKey("Navigation_Question")]
        public int? Q_Id { get; set; }
        public string Student_Answer { get; set; }
        public int Result { set; get; }


        #region NavigationProperty
        public Question Navigation_Question { get; set; }
        public Exam Navigation_Exam { get; set; }

        #endregion
    }
}
