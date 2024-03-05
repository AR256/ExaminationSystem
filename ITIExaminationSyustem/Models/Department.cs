using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITIExaminationSyustem.Models
{
    public class Department
    {
        [Key]
        public int Department_Id { get; set; }

        //public string Department_Name { get; set; }

        [ForeignKey("Navigation_Department_Manager_Instructor")]
        public int? Department_MgrId { set; get; }

        [ForeignKey("Navigation_Branch")]
        public int? Brch_Id { get; set; }

        [ForeignKey("Navigation_MainDepartment")]
        public int? MainDept_Id { get; set; }


        #region Navigation


        public Instructor Navigation_Department_Manager_Instructor { get; set; }

       
        public ICollection<DepartmentInstructors> Navigation_Department_Instructor {  set; get; } = new HashSet<DepartmentInstructors>();

        //-----------------------------------------------------------------------------
        public ICollection<Course> Navigation_Courses { get; set; } = new HashSet<Course>();
        //-----------------------------------------------------------------------------
        public ICollection<Student> Navigation_Students { get; set; } = new HashSet<Student>();

        //-----------------------------------------------------------------------------
        public  Branch Navigation_Branch { get; set; }
        public MainDepartment Navigation_MainDepartment { get; set; }
        #endregion

    }
}
