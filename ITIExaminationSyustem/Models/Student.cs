using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITIExaminationSyustem.Models
{
    public class Student
    {
        [Key]
        public int Student_Id { get; set; }     
        public string Student_Name { get; set; }
        public string Student_Password { get; set; }
        public string Student_Email { get; set; }


        [ForeignKey("Navigation_Department")]
        public int? Dept_Id { get; set; }



        #region Navigation property
        public Department Navigation_Department { get; set; }
        //----------------------------------------------------
        public ICollection<StudentCourses> Navigation_StudentCourses { get; set; } = new HashSet<StudentCourses>();
        //----------------------------------------------------
        public ICollection<Exam> Navigation_StudentExam { get; set; } = new HashSet<Exam>();


        #endregion
    }
}
