using ITIExaminationSyustem.Interfaces;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITIExaminationSyustem.Models
{
    public class Exam
    {
        [Key]
        public int Exam_Id { get; set; }
        public  int? Grade { get; set; }

        


        [ForeignKey("Navigation_Course")]
        public int? Crs_Id { get; set; }


        [ForeignKey("Navigation_Student")]
        public  int?  StudId { get; set; }





        #region Navigation property
        public Student Navigation_Student { get; set; }
        //-------------------------------------------------
        public  Course Navigation_Course { get; set; }
        //-------------------------------------------------
        public ICollection<ExamQs> Navigation_ExamQs { get; set; }=new HashSet<ExamQs>();   

        #endregion
    }
}
