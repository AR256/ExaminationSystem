using System.ComponentModel.DataAnnotations;

namespace ITIExaminationSyustem.Models
{
    public class Course
    {
        [Key]
        public int Course_Id { get; set; }
        public string Course_Name { get; set; }
        public int Course_Duration { get; set; }

        #region Navigation property
        
        public ICollection<Instructor> Navigation_Instructors { get; set; } = new HashSet<Instructor>();
        
        public ICollection<Department> Navigation_Departments { get; set; } = new HashSet<Department>();
        //-----------------------------------------------------------------------------
        public ICollection<StudentCourses> Navigation_StudentCourses { get; set; } = new HashSet<StudentCourses>();

        //-----------------------------------------------------------------------------
        public ICollection<Exam> Navigation_Exam { get; set; } = new HashSet<Exam>();

        //-----------------------------------------------------------------------------
        public ICollection<Question> Navigation_Question { get; set; } = new HashSet<Question>();


        #endregion
    }
}
