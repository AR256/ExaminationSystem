using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITIExaminationSyustem.Models
{
    public class Student
    {
        [Key]
        public int Student_Id { get; set; }     
        public string Student_Name { get; set; }
       
        [ForeignKey("Navigation_User")]
        public int? Std_User_Id { get; set; }


        [ForeignKey("Navigation_Department")]
        public int? Dept_Id { get; set; }


        





        #region Navigation property
        public Department Navigation_Department { get; set; }
        //----------------------------------------------------
        public ICollection<StudentCourse> Navigation_StudentCourses { get; set; } = new HashSet<StudentCourse>();
        //----------------------------------------------------
        public ICollection<Exam> Navigation_StudentExam { get; set; } = new HashSet<Exam>();
        //-----------------------------------------------------------------------------

        public User Navigation_User { get; set; }
        #endregion
    }
}
