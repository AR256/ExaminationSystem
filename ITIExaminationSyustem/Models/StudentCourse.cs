using System.ComponentModel.DataAnnotations.Schema;

namespace ITIExaminationSyustem.Models
{
    public class StudentCourse
    {
        [ForeignKey("Navigation_Student")]
        public int? Std_Id { get; set; }
        [ForeignKey("Navigation_Course")]
        public int? Crs_Id { get; set; }
        public int? Grade { get; set; }
        public int Bonus { get; set; }
        public string Ins_Feedback { get; set; }
        public string Std_Feedback { get; set; }
        public bool HasTakenExam { get; set; } = false;





        #region Navigation property
        public Course Navigation_Course { get; set; }
        public Student Navigation_Student { get; set; }
        #endregion
    }
}
