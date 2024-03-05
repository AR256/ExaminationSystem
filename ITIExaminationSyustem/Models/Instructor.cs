using System.ComponentModel.DataAnnotations;

namespace ITIExaminationSyustem.Models
{
    public class Instructor
    {
        [Key]
        
        public int Instructor_Id { get; set; }
        public string Instructor_Name { get; set; }
        public string Instructor_Email { get; set; }
        public string Instructor_Password { get; set; }


        #region Navigation

        
        public ICollection<Department> Departments { get; set; } = new HashSet<Department>();

        
        public ICollection<DepartmentInstructors> Navigation_Department_Instructor { set; get; } = new HashSet<DepartmentInstructors>();
        //-----------------------------------------------------------------------------
        public ICollection<Course> Courses { get; set; } = new HashSet<Course>();

        #endregion
    }
}
