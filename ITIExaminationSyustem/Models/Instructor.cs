using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITIExaminationSyustem.Models
{
    public class Instructor
    {
        [Key]
        
        public int Instructor_Id { get; set; }

        [ForeignKey("Navigation_User")]
        public int? Ins_User_Id { get; set; }






        #region Navigation
        public ICollection<Department> Departments { get; set; } = new HashSet<Department>();       
        public ICollection<DepartmentInstructors> Navigation_Department_Instructor { set; get; } = new HashSet<DepartmentInstructors>();
        //-----------------------------------------------------------------------------
        public ICollection<Course> Courses { get; set; } = new HashSet<Course>();
        //-----------------------------------------------------------------------------
        public User Navigation_User { get; set; }
        #endregion
    }
}
